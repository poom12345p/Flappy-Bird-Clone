using System;
using System.Collections.Generic;
using Sigleton;
using UnityEngine;


public class GameManager : BaseSingleton<GameManager>
{
    #region public
    public PlayerControl Player => _playerControl;
    public int HighScore =>_scoreSaveControl.HighScore;
    public int LastScore =>_scoreSaveControl.HighScore;
    
    #endregion

    #region control
    [SerializeField] private PlayerControl _playerControl;
    private ScoreSaveControl _scoreSaveControl;

    #endregion

    #region states
    [Header("States")]
    [SerializeField]private MainMenuStateManager _mainMenuStateManager;
    [SerializeField]private GamePlayStateManager _gamePlayStateManager;
    
    #endregion

    #region private
    private readonly Dictionary<Type,StateManager> _stateManagers = new Dictionary<Type,StateManager>();
    private StateManager _currentState;
    #endregion
    
    void Start()
    {
        _scoreSaveControl= new ScoreSaveControl();
        GoToState(_mainMenuStateManager);
    }

    #region public methods
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
    
    #endregion
    
    #region private methods
    private void GoToState(StateManager stateManager)
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
    #endregion

}

