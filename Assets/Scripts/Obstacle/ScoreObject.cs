using UnityEngine;

public class ScoreObject : GameplayStateObject, ITriggerableObject
{

    
    public void Trigger()
    {
        _stateManager?.AddScore();
        gameObject.SetActive(false);
    }
}
