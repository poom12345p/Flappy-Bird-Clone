using System;
using System.Collections.Generic;
using Sigleton;
using UnityEngine;


public class GameManager : BaseSingleton<GameManager>
{
    public PlayerControl Player => _playerControl;
    public int HighScore =>_scoreSaveControl.HighScore;
    public int LastScore =>_scoreSaveControl.HighScore;
    [SerializeField] private PlayerControl _playerControl;
    private ScoreSaveControl _scoreSaveControl;
    
    [Header("States")]
    [SerializeField]private MainMenuStateManager _mainMenuStateManager;
    [SerializeField]private GamePlayStateManager _gamePlayStateManager;

    private readonly Dictionary<Type,StateManager> _stateManagers = new Dictionary<Type,StateManager>();
    private StateManager _currentState;
    
    void Start()
    {
        _scoreSaveControl= new ScoreSaveControl();
        GoToState(_mainMenuStateManager);
    }

    public void GoToState(StateManager stateManager)
    {
        

        if (!_stateManagers.TryGetValue(stateManager.GetType(), out StateManager state))
        {
            state = Instantiate(stateManager);
            _stateManagers.Add(stateManager.GetType(),state);
            state.InitState();
        }
        _currentState?.ExitState();
        _currentState =state;
        _currentState.EnterState();
    }
    public void StartGame()
    {
        GoToState(_gamePlayStateManager);
    }
    
    public void GoToMainMenu()
    {
        GoToState(_mainMenuStateManager);
    }
    public void SaveScore(int score)
    {
        _scoreSaveControl.TrySaveHighScore(score);
    }
}

