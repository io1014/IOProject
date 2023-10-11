using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcessManager : GenericSingleTon<GameProcessManager>
{
    FSM fsm = null;
    protected override void OnWake()
    {
        base.OnWake();
        fsm = new FSM();
    }
    void Start()
    {
        //로딩상태로 전환한다.
        fsm.ChanageState(new LoadingState(fsm));
        
    }

       void Update()
    {
        fsm.DoLoop(); // 반복 실행을 매 프레임마다 
        
    }
    public void ChangeState(gameStateType type)
    {
        switch(type)
        {
            case gameStateType.loading: fsm.ChanageState(new LoadingState(fsm)); break;
            case gameStateType.inGame: fsm.ChanageState(new InGameState(fsm));break;
            case gameStateType.pause: fsm.ChanageState(new PauseState(fsm));break;
            case gameStateType.clear: fsm.ChanageState(new GameClearState(fsm));break;
        }
        
    }
}
public enum gameStateType
{
    loading,
    inGame,
    pause,
    clear,

}

public class FSM
{
    protected FSMState _currentState;

    public void ChanageState(FSMState state)
    {
        _currentState?.OnExit();
        _currentState = state;
        _currentState.OnEnter();
    }
    public void DoLoop() => _currentState?.DoLoop();
}

public abstract class FSMState
{
    protected FSM _baseFSM;
    public FSMState(FSM fsm) { _baseFSM = fsm; }

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract void DoLoop();
}
public class LoadingState : FSMState
{
    public LoadingState(FSM fsm) : base(fsm) { }

    public override void OnEnter()
    {
        // task : 로딩씬이 아니라면 로딩씬 실행하기
        // task : UIBase 초기화
        if (SceneManager.GetActiveScene().name != "Lobby") SceneManager.LoadScene("Lobby");
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().UIInit();

        //task : 텍스트 리소스 베이스에 리소스를 로드하라고 시킴
        GenericSingleTon<TextResourceBase>.Instance.GetComponent<TextResourceBase>().LoadData();
        
    }
    public override void OnExit()
    {
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowLobbyUI(false);
        
    }
    public override void DoLoop()
    {
        // task : 리소스 로드가 끝났으면 loadingTextUI는 끄고 UI표시하라고 UI한테 시킴
        if(GenericSingleTon<TextResourceBase>.Instance.GetComponent<TextResourceBase>().isLoadFinish())
        {
            //버튼보이기
            //loadingText 끄고
            GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowLobbyButton(true);
            GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowLoadingText(false);
        }
    }
}

public class InGameState : FSMState
{
    public InGameState(FSM fsm) : base(fsm) { }

    public override void OnEnter()
    {
        //task : 인게임 UI를 켜준다.
        //타임스케일을 1로 바꿔준다. -> 포즈(puase)상태가 되면 타임스케일을 0으로 바꿔서 게임동작을 정지할 계획
        //현재 씬이 게임씬이 아니면 게임씬으로 바꿔준다. // 포즈 상태가 되도 게임씬이기 때문에 항상 게임씬을 새로 로드하면 안됨
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowinGameUI(true); // InGameUI패널 전체를 켜줌
        Time.timeScale = 1f; // 타임스케일이란 실제시간에 곱해줄 크기
        if(SceneManager.GetActiveScene().name !="GameScene") SceneManager.LoadScene("GameScene");

    }
    public override void DoLoop()
    {
      
    }

    public override void OnExit()
    {
      
    }
}

public class PauseState : FSMState
{
    public PauseState(FSM fsm) : base(fsm) { }

    public override void OnEnter()
    {
      //task : 옵션 UI패널 열기
      //task : 타임스케일 0 으로 바꿔서 게임동작을 정지
      Time.timeScale = 0f; // 실제 시간에 곱해지는 타임스케일이 0이 되면서 시간 흐름 정지
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowoptionUI(true);
    }
    public override void DoLoop()
    {
        
    }
    public override void OnExit() 
    {
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowoptionUI(false);
    }

}

public class GameClearState : FSMState
{
    public GameClearState(FSM fsm) : base(fsm) { }

    public override void OnEnter()
    {

        Time.timeScale = 0f;
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowclearUI(true);
        
    }

    public override void DoLoop()
    {
        
    }

    public override void OnExit()
    {
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowclearUI(false);
        Time.timeScale = 1;
    }
}






// GameClearState를 하나 만듭니다.
// 좀비가 사망시 실행됨
// 게임 클리어 UI가 팝됩니다. 게임 시간이 멈춥니다
// 게임 클리어 UI는 스케일 애니메이션 되야 합니다.
// 게임 클리어 UI에 버튼이 있어서 누르면 Lobby화면으로 이동합니다.