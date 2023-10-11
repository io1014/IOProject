using UnityEngine;

public abstract class GameObjectFSM : MonoBehaviour // animator controlleró�� state�� �����Ű�� �����ϴ� Ŭ����
{
    GameObjectFSMState _currentState; 
    // -> animator controller���� ������ ���� State���� ������ ���������� �ϳ��� ������ ����

    public void ChangeState(GameObjectFSMState nextState)
    {
        _currentState?.OnExit(); //_currentState�� null�� �ƴҶ� onExit()�Լ� ����
        //if (_currentState != null) _currentState.OnExit(); �� ������ ����
        _currentState = nextState;
        _currentState?.OnEnter(); // ���°� ���̵��ڸ��� �ٷ� ����Ǵ� �Լ�
    }

    void Update()
    {
        _currentState?.DoLoop(); // ������ �ݺ� ������ ����
    }
}

public abstract class GameObjectFSMState // animator Controller�ȿ� ��ġ�Ǵ� stateó�� ���������� �����ϰ� �����ϴ� �θ� Ŭ����
{
    protected GameObject _obj;
    public GameObjectFSMState(GameObject obj) => _obj = obj; // ������ ������ �ʿ�

    public abstract void OnEnter(); // ó�� ���°� ��ȭ�Ǹ� ��� �����ϴ� �Լ�
    public abstract void DoLoop(); // updateó�� ���°� ���ӵǴ� ���� �ݺ� ����Ǵ� �Լ�
    public abstract void OnExit(); // ������ ������ ������ �ɶ� ����Ǵ� �Լ� 
}

public class ZombieIdleState : GameObjectFSMState
{
    FSMPractice _baseComp;
    ZombieFSM _baseFSM;
    float _timer;
    public ZombieIdleState(GameObject obj) : base(obj) { } // �θ��� �����ڴ� �ڽ��� ������ : ����
    public override void DoLoop()
    {
        CheckTransition();
    }

    void CheckTransition() // ���� ��ȭ�� �����ϰ� �����ϴ� ��ü
    {
        _timer += Time.deltaTime;
        if(_timer > 1)
        {
            // ��Ʈ�ѷ� ���� ��ȯ
            _baseFSM.ChangeStateByEnum(ZombieState.Patroll);
        }
    }

    public override void OnEnter()
    {
        // _obj���� animator�� �����ͼ� Idle �ִϸ��̼��� �����ϰ�
        // �ð��� �ʱ�ȭ
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
    //������
    //doLoop
    //onEnter
    //onExit
    float _moveSpeed;
    FSMPractice _baseComp;
    Vector3 _targetPos; // ��Ʈ�� Ÿ�� ��ġ
    Transform _targetTransform;// Ÿ�� ������Ʈ �������
    ZombieFSM _baseFSM; // ���� ��ȯ�� ���ؼ�

    bool _isEndPoint = false;

    public ZombiePatrollState(GameObject obj) : base(obj) { }
    public override void OnEnter()
    {
        // task : FSMPractice���� �������� �����´�.
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
        // task : �������� �̵��Ѵ�.
        // �������� �����ϸ� idle ���·� ��ȯ�Ѵ�.
        // ���� �����Ÿ� �ȿ� Ÿ���� ������ attackmove���·� ��ȯ�Ѵ�.
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
            _baseFSM.ChangeStateByEnum(ZombieState.AttackMove);// �̰� ���� �ȸ��� ����
        }
    }
    public override void OnExit()
    {
        // FSMPractice�� ������ �ε����� �ϳ� ������Ų��.
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
        // task : Move �ִϸ��̼� ����
        // task : ��� transform ���� ȹ��
        // task : ���� �̵��ӵ� ���� ȹ��
        _baseComp = _obj.GetComponent<FSMPractice>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _attackMoveSpeed = _baseComp.GetAttackMoveSpeed();
        _targetTrans = _baseComp.GetTargetTrans();
    }
    public override void DoLoop()
    {
        // task : ��� transform ��ġ�� ���� �̵��ӵ��� �ӵ��� �̵�
        // task : Ʈ������1 : �Ÿ��� 2 ���ϰ� �Ǹ� attack ���·� ����
        // task : Ʈ������2 : �Ÿ��� 10�̻��� �Ǹ� Idle ���·� ����
        // task : ���� �̵��߿��� scale�� Ŀ���� �۾����� �ݺ�
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
        Debug.Log($"������ : {(Mathf.Sin(_scaleTimer * Mathf.PI))} , {_scaleTimer}");
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
        // task : ��� �����̵� ������ ũ�� ����
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
        // task : FSMPractic�� �ִϸ��̼� Die�� ���� ��û
        // task : ZombieFSM�� callback ��� 
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
        // task : _obj -> ������ ���̽� ���ӿ�����Ʈ�� �ı�
        GameObject.Destroy(_obj);
        GenericSingleTon<GameProcessManager>.Instance.GetComponent<GameProcessManager>().ChangeState(gameStateType.clear);
    }
}

// AttackState
// ���� : ZombieAttackState ��� ���¸� �ϳ� �����Ұ�
// �̻��´� ZombieAttackMoveState���� ������ �Ÿ��� 2�����϶� ���̵Ǿ� �����
// �� ���´� OnEnter���� Attack�ִϸ��̼��� ������
// Attack�ִϸ��̼��� ������ �����ӿ� �ݹ��� �ɾ
// ZombieAttackMoveState���·� ���̵�
// ���þִϸ��̼��� ZombieBase�ڽ����� ������ ������ ������ Cube���ӿ�����Ʈ�� �ִϸ��̼� Ŭ������ �����ؼ� ������
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

