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
        //�ε����·� ��ȯ�Ѵ�.
        fsm.ChanageState(new LoadingState(fsm));
        
    }

       void Update()
    {
        fsm.DoLoop(); // �ݺ� ������ �� �����Ӹ��� 
        
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
        // task : �ε����� �ƴ϶�� �ε��� �����ϱ�
        // task : UIBase �ʱ�ȭ
        if (SceneManager.GetActiveScene().name != "Lobby") SceneManager.LoadScene("Lobby");
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().UIInit();

        //task : �ؽ�Ʈ ���ҽ� ���̽��� ���ҽ��� �ε��϶�� ��Ŵ
        GenericSingleTon<TextResourceBase>.Instance.GetComponent<TextResourceBase>().LoadData();
        
    }
    public override void OnExit()
    {
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowLobbyUI(false);
        
    }
    public override void DoLoop()
    {
        // task : ���ҽ� �ε尡 �������� loadingTextUI�� ���� UIǥ���϶�� UI���� ��Ŵ
        if(GenericSingleTon<TextResourceBase>.Instance.GetComponent<TextResourceBase>().isLoadFinish())
        {
            //��ư���̱�
            //loadingText ����
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
        //task : �ΰ��� UI�� ���ش�.
        //Ÿ�ӽ������� 1�� �ٲ��ش�. -> ����(puase)���°� �Ǹ� Ÿ�ӽ������� 0���� �ٲ㼭 ���ӵ����� ������ ��ȹ
        //���� ���� ���Ӿ��� �ƴϸ� ���Ӿ����� �ٲ��ش�. // ���� ���°� �ǵ� ���Ӿ��̱� ������ �׻� ���Ӿ��� ���� �ε��ϸ� �ȵ�
        GenericSingleTon<UIBase>.Instance.GetComponent<UIBase>().ShowinGameUI(true); // InGameUI�г� ��ü�� ����
        Time.timeScale = 1f; // Ÿ�ӽ������̶� �����ð��� ������ ũ��
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
      //task : �ɼ� UI�г� ����
      //task : Ÿ�ӽ����� 0 ���� �ٲ㼭 ���ӵ����� ����
      Time.timeScale = 0f; // ���� �ð��� �������� Ÿ�ӽ������� 0�� �Ǹ鼭 �ð� �帧 ����
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






// GameClearState�� �ϳ� ����ϴ�.
// ���� ����� �����
// ���� Ŭ���� UI�� �˵˴ϴ�. ���� �ð��� ����ϴ�
// ���� Ŭ���� UI�� ������ �ִϸ��̼� �Ǿ� �մϴ�.
// ���� Ŭ���� UI�� ��ư�� �־ ������ Lobbyȭ������ �̵��մϴ�.