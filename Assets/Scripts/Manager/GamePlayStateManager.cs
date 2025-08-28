using System;
using UnityEngine;

public class GamePlayStateManager  : StateManager
{
    private enum States
    {
        PRESTART,PLAYING,OVER
    }
    [SerializeField]private ObstacleManager ObstacleManager;
    [SerializeField]private ScoreManager ScoreManager;
    [SerializeField]private PlayerInputControl playerInputControl;
    [SerializeField]private UIControl _tapUIPrefab;
    [SerializeField] private ResultUI _resultUIPrefab;
    
    private UIControl tapUI;
    private ResultUI _resultUI;
    
    private States state;
    public override void InitState()
    {
        ScoreManager.Init();
        ObstacleManager.Init(this);
        playerInputControl.Init();
        playerInputControl.TapAction += GameManager.Instance.Player.Flap;
        playerInputControl.TapAction +=PlayState;
        tapUI = Instantiate(_tapUIPrefab);
        _resultUI = Instantiate(_resultUIPrefab);
        playerInputControl.enabled = false;
    }
    
    public override void EnterState()
    {
        Reset();
    }

    public override void ExitState()
    {
        tapUI.Hide();
        _resultUI.Hide();
        ObstacleManager.ClearObstacle();
        GameManager.Instance.Player.Reset();
    }

    public void Reset()
    {
        state = States.PRESTART;
        playerInputControl.enabled = true;
        
        tapUI.Show();
        _resultUI.Hide();
        
        ObstacleManager.ClearObstacle();
        ScoreManager.StartScore();
        GameManager.Instance.Player.Reset();
    }

    public void AddScore()
    {
        ScoreManager.AddScore();
    }

    public void PlayState()
    {
        if(state!= States.PRESTART) return;
        GameManager.Instance.Player.Activate();
        state = States.PLAYING;
        ObstacleManager.StartObstacle();
        tapUI.Hide();
        
    }
    
    public  void GameOver()
    {
        if(state!= States.PLAYING) return;
        state = States.OVER;
        
        GameManager.Instance.Player.Dead();
        _resultUI.Show();
        ScoreManager.GameOver();
        ObstacleManager.StopObstacle();
        playerInputControl.enabled = false;
        _resultUI.SetScore( ScoreManager.Score);
        _resultUI.Show();
    }
}


