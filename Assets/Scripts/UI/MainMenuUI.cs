using UnityEngine;

public class MainMenuUI : BaseUI
{

    [SerializeField]HightScorePopUpUI _highScorePopUpUIPrefab;
    [SerializeField]SoundSettingUI _soundSettingPopUpUIPrefab;
    
    private HightScorePopUpUI _highScorePopUpUI;
    private SoundSettingUI _soundSettingPopUpUI;
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowHighScorePopUpUI()
    {
        if(!_highScorePopUpUI)_highScorePopUpUI = Instantiate(_highScorePopUpUIPrefab,_uiControl.Canvas.transform);
        _highScorePopUpUI.Show();
    }
    public void ShosoundSettingPopUpUI()
    {
        if(! _soundSettingPopUpUI) _soundSettingPopUpUI= Instantiate( _soundSettingPopUpUIPrefab,_uiControl.Canvas.transform);
        _soundSettingPopUpUI.Show();
    }
}
