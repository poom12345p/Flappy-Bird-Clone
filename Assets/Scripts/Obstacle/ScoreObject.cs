using UnityEngine;

public class ScoreObject : GameplayStateObject, ITriggerableObject
{

    public AudioClip triggerSound;
    public void Trigger()
    {
        _stateManager?.AddScore();
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound(triggerSound);
    }
}
