using UnityEngine;

public class MainMenuStateManager : StateManager
{
    [SerializeField]private UIControl mainUIPrefab ;
    [SerializeField]AudioClip MainMenuBGM;
    private UIControl mainUI;

    public override void InitState()
    {
        mainUI = Object.Instantiate(mainUIPrefab);
    }

    public override void EnterState()
    {
        mainUI.Show();
        GameManager.Instance.Player.Reset();
        SoundManager.Instance.PlayBGM(MainMenuBGM);
    }

    public override void ExitState()
    {
        mainUI.Hide();
    }
}
