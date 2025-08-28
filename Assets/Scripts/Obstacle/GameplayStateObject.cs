using UnityEngine;

public class GameplayStateObject : MonoBehaviour
{
    protected GamePlayStateManager _stateManager;

    public void SetStateManager(GamePlayStateManager stateManager)
    {
        _stateManager = stateManager;
    }
}
