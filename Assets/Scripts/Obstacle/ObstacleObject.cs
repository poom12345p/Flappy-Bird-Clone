using System;
using System.Collections.Generic;
using ObjectPooling;
using PrimeTween;
using UnityEngine;

public class ObstacleObject : MonoBehaviour,IPoolable
{
    
    [SerializeField]ScoreObject scoreObject;

    [SerializeField]private List<GameplayStateObject>  gameplayStateObjects;
    private Tween tween=new Tween();
    public GameObject OriginPref { get; set; }


    public void Init(GamePlayStateManager gamePlayStateManager)
    {
        foreach (var obj in  gameplayStateObjects)
        {
            obj.SetStateManager(gamePlayStateManager);
        }
    }
    public void OnGet()
    {
        gameObject.SetActive(true);
        scoreObject.gameObject.SetActive(true);
    }

    public void OnRelease()
    {
        tween.Stop();
        gameObject.SetActive(false);
    }

    public void OnDestroy()
    {

    }
    

    public Tween Move(float PosX, float duration)
    {
        tween.Stop();
        var tweenSettingsFloat = new TweenSettings<float>(endValue: PosX, duration, updateType: UpdateType.FixedUpdate,ease: Ease.Linear);
        var newTween = Tween.PositionX(transform,tweenSettingsFloat);
        tween = newTween;
        return newTween;
    }

    public void Stop()
    {
        tween.Stop();
    }
}
