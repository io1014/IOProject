using UnityEngine;

public abstract class GameObjectFSM : MonoBehaviour // animator controller처럼 state를 실행시키고 관리하는 클래스
{
    GameObjectFSMState _currentState; 
    // -> animator controller에서 실행할 현재 State같이 현재의 상태정보를 하나의 변수에 저장

    public void ChangeState(GameObjectFSMState nextState)
    {
        _currentState?.OnExit(); //_currentState가 null이 아닐때 onExit()함수 실행
        //if (_currentState != null) _currentState.OnExit(); 와 동일한 구문
        _currentState = nextState;
        _currentState?.OnEnter(); // 상태가 전이되자마자 바로 실행되는 함수
    }

    void Update()
    {
        _currentState?.DoLoop(); // 상태의 반복 실행을 진행
    }
}

public abstract class GameObjectFSMState // animator Controller안에 배치되는 state처럼 상태정보를 저장하고 동작하는 부모 클래스
{
    protected GameObject _obj;
    public GameObjectFSMState(GameObject obj) => _obj = obj; // 강제로 생성자 필요

    public abstract void OnEnter(); // 처음 상태가 변화되면 즉시 실행하는 함수
    public abstract void DoLoop(); // update처럼 상태가 지속되는 동안 반복 실행되는 함수
    public abstract void OnExit(); // 상태의 동작이 마무리 될때 실행되는 함수 
}

public class ZombieIdleState : GameObjectFSMState
{
    FSMPractice _baseComp;
    ZombieFSM _baseFSM;
    float _timer;
    public ZombieIdleState(GameObject obj) : base(obj) { } // 부모의 생성자는 자식의 생성자 : 실행
    public override void DoLoop()
    {
        CheckTransition();
    }

    void CheckTransition() // 상태 변화를 감시하고 진행하는 객체
    {
        _timer += Time.deltaTime;
        if(_timer > 1)
        {
            // 패트롤로 상태 변환
            _baseFSM.ChangeStateByEnum(ZombieState.Patroll);
        }
    }

    public override void OnEnter()
    {
        // _obj에서 animator를 가져와서 Idle 애니메이션을 실행하고
        // 시간을 초기화
        _timer = 0;
        _baseComp = _obj.GetComponent<FSMPractice>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _baseComp.StartAnim("Idle");
    }
    public override void OnExit()
    {

    }
}

public class ZombiePatrollState : GameObjectFSMState
{
    //생성자
    //doLoop
    //onEnter
    //onExit
    float _moveSpeed;
    FSMPractice _baseComp;
    Vector3 _targetPos; // 패트롤 타겟 위치
    Transform _targetTransform;// 타겟 오브젝트 영웅대상
    ZombieFSM _baseFSM; // 상태 전환을 위해서

    bool _isEndPoint = false;

    public ZombiePatrollState(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        // task : FSMPractice에서 목적지를 가져온다.
        _baseComp = _obj.GetComponent<FSMPractice>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _moveSpeed = _baseComp.GetMoveSpeed();
        _targetPos = _baseComp.GetNowPatPoint().position;
        _targetTransform = _baseComp.GetTargetTrans();
        _baseComp.StartAnim("Move");
        _isEndPoint = false;
    }
    public override void DoLoop()
    {
        // task : 목적지로 이동한다.
        // 목적지에 도달하면 idle 상태로 전환한다.
        // 만약 일정거리 안에 타겟이 들어오면 attackmove상태로 전환한다.
        _obj.transform.position += (_targetPos - _obj.transform.position).normalized * _moveSpeed * Time.deltaTime;
        CheckTransition();
    }
    void CheckTransition()
    {
        if (Vector3.Distance(_targetPos, _obj.transform.position) < 0.1f)
        {
            _isEndPoint = true;
            _baseFSM.ChangeStateByEnum(ZombieState.Idle);
        }
        if(Vector3.Distance(_targetTransform.position, _obj.transform.position) < 10)
        {
            _baseFSM.ChangeStateByEnum(ZombieState.AttackMove);// 이건 아직 안만들어서 오류
        }
    }
    public override void OnExit()
    {
        // FSMPractice의 목적지 인덱스를 하나 증가시킨다.
        if(_isEndPoint == true)_baseComp.AddPatIndex();
    }
}

public class ZombieAttackMoveState : GameObjectFSMState
{
    FSMPractice _baseComp;
    ZombieFSM _baseFSM;
    float _attackMoveSpeed;
    Transform _targetTrans;
    public ZombieAttackMoveState(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        // task : Move 애니메이션 실행
        // task : 대상 transform 정보 획득
        // task : 전투 이동속도 정보 획득
        _baseComp = _obj.GetComponent<FSMPractice>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _attackMoveSpeed = _baseComp.GetAttackMoveSpeed();
        _targetTrans = _baseComp.GetTargetTrans();
    }
    public override void DoLoop()
    {
        // task : 대상 transform 위치로 전투 이동속도의 속도로 이동
        // task : 트랜지션1 : 거리가 2 이하가 되면 attack 상태로 전이
        // task : 트랜지션2 : 거리가 10이상이 되면 Idle 상태로 전이
        // task : 전투 이동중에는 scale이 커졌다 작아졌다 반복
        _obj.transform.position += (_targetTrans.position - _obj.transform.position).normalized * _attackMoveSpeed * Time.deltaTime;
        ScalePingPong();
        CheckTransition();
    }
    float _scaleTimer = 0;
    void ScalePingPong()
    {
        _scaleTimer += Time.deltaTime;
        if (_scaleTimer >= 1) _scaleTimer = 0;
        _obj.transform.localScale = Vector3.one * (Mathf.Sin(_scaleTimer * Mathf.PI) + 0.5f);
        Debug.Log($"싸인파 : {(Mathf.Sin(_scaleTimer * Mathf.PI))} , {_scaleTimer}");
    }

    void CheckTransition()
    {
        if (Vector3.Distance(_targetTrans.position, _obj.transform.position) < 2f)
        {
            _baseFSM.ChangeStateByEnum(ZombieState.Attack);
        }
        if(Vector3.Distance(_targetTrans.position, _obj.transform.position) > 10f)
        {
            _baseFSM.ChangeStateByEnum(ZombieState.Idle);
        }
    }

    public override void OnExit()
    {
        // task : 모든 전투이동 종료후 크기 리셋
        _obj.transform.localScale = Vector3.one;
    }
}

public class ZombieDieState : GameObjectFSMState
{
    FSMPractice _baseComp;
    ZombieFSM _baseFSM;
    public ZombieDieState(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        // task : FSMPractic에 애니메이션 Die를 실행 요청
        // task : ZombieFSM에 callback 등록 
        _baseComp = _obj.GetComponent<FSMPractice>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _baseComp.StartAnim("Die");
        _baseFSM.SetAnimStateCallback(OnExit);
    }
    public override void DoLoop()
    {
    }
    public override void OnExit()
    {
        // task : _obj -> 좀비의 베이스 게임오브젝트를 파괴
        GameObject.Destroy(_obj);
        GenericSingleTon<GameProcessManager>.Instance.GetComponent<GameProcessManager>().ChangeState(gameStateType.clear);
    }
}

// AttackState
// 문제 : ZombieAttackState 라는 상태를 하나 생성할것
// 이상태는 ZombieAttackMoveState에서 상대와의 거리가 2이하일때 전이되어 실행됨
// 이 상태는 OnEnter에서 Attack애니메이션을 실행함
// Attack애니메이션의 마지막 프레임에 콜백을 걸어서
// ZombieAttackMoveState상태로 전이됨
// 어택애니메이션은 ZombieBase자식으로 생성한 길쭉한 형태의 Cube게임오브젝트를 애니메이션 클립으로 제어해서 실행함
public class ZombieAttAckState : GameObjectFSMState
{
    FSMPractice _baseComp;
    ZombieFSM _baseFSM;
    public ZombieAttAckState(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        _baseComp = _obj.GetComponent<FSMPractice>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _baseComp.StartAnim("Attack");
        _baseFSM.SetAnimStateCallback(() => _baseFSM.ChangeStateByEnum(ZombieState.AttackMove));


    }
    public override void DoLoop()
    {

    }
    public override void OnExit()
    {
        
    }
}

