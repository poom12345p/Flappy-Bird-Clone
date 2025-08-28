using UnityEngine;

public class GameOverObject : GameplayStateObject , ITriggerableObject
{

    public void Trigger()
    {
       _stateManager.GameOver();
    }
}
