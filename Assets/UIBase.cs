using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : GenericSingleTon<UIBase>
{
    [SerializeField] GameObject _lobbyUI;
    [SerializeField] GameObject _loadingText;
    [SerializeField] GameObject _lobbyButton;
    [SerializeField] GameObject _inGameUI;
    [SerializeField] GameObject _optionUI;
    [SerializeField] GameObject _clearUI;

    // 전체 UI 초기화 함수
    public void UIInit()
    {
        _lobbyUI.SetActive(true);
        _inGameUI.SetActive(false);
        _optionUI.SetActive(false);
        _clearUI.SetActive(true);
    }

    public void ShowLobbyUI(bool isshow) => _lobbyUI.SetActive(isshow);
    public void ShowLoadingText(bool isshow) => _loadingText.SetActive(isshow);

    public void ShowLobbyButton(bool isshow) => _lobbyButton.SetActive(isshow);

    public void ShowinGameUI(bool isshow) => _inGameUI.SetActive(isshow);

    public void ShowoptionUI(bool isshow)
    {
        if (isshow == true)
        {

            _optionUI.SetActive(true);
            _optionUI.GetComponent<Animator>().SetBool("OptionView", true);
        }
        else
        {
            _optionUI.GetComponent<Animator>().SetBool("OptionView", false);
            Invoke("ShowOffOptioUI", 0.15f);
        }
    }

    public void ShowclearUI(bool isshow)
    {
        if (isshow == true)
        {

            _clearUI.SetActive(true);
            _clearUI.GetComponent<Animator>().SetBool("Clear", true);
        }
        else
        {
            _clearUI.GetComponent<Animator>().SetBool("Clear", false);
            Invoke("ShowOffOptioUI", 0.15f);
        }
    }
    void ShowOffOptioUI()
    {
        _optionUI.SetActive(false);
    }
    public void OnBtnDoGame() => GenericSingleTon<GameProcessManager>.Instance.GetComponent<GameProcessManager>().ChangeState(gameStateType.inGame);

    public void OnBtnRestart() => GenericSingleTon<GameProcessManager>.Instance.GetComponent<GameProcessManager>().ChangeState(gameStateType.loading);
    
    public void OnBtnShowOption()
    {
        // 인게임에서 눌리면 옵션패널을 켜고
        // 옵션패널에서 눌리면 옵션패널을 끈다.
        if(_optionUI.activeSelf ==true)
        {
            GenericSingleTon<GameProcessManager>.Instance.GetComponent<GameProcessManager>().ChangeState(gameStateType.inGame);

        }
        else
        {
            GenericSingleTon<GameProcessManager>.Instance.GetComponent<GameProcessManager>().ChangeState(gameStateType.pause);
        }
    }

}
