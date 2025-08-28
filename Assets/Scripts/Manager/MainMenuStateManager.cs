using UnityEngine;

public class MainMenuStateManager : StateManager
{
    [SerializeField]private UIControl mainUIPrefab ;
    
    private UIControl mainUI;

    public override void InitState()
    {
        mainUI = Object.Instantiate(mainUIPrefab);
    }

    public override void EnterState()
    {
        mainUI.Show();
        GameManager.Instance.Player.Reset();
    }

    public override void ExitState()
    {
        mainUI.Hide();
    }
}
