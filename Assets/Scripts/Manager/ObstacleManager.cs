using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObstacleManager : MonoBehaviour
{
    [SerializeField]ObstacleObject obstacle;
    [SerializeField] private float delay;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float startX;
    [SerializeField] private float endX;
    [SerializeField] private float duration;
    public  List<GameplayStateObject> GameplayStateObjects;
    private List<ObstacleObject> obstaclePool=new();
    private WaitForSeconds wait;
    private Coroutine coroutine;
    private GamePlayStateManager _stateManager;

    public void Init(GamePlayStateManager stateManager)
    {
        wait = new WaitForSeconds(delay);
        _stateManager = stateManager;
        foreach (var obj in  GameplayStateObjects)
        {
            obj.SetStateManager(stateManager);
        }
    }
    // private void Awake()
    // {
    //     wait = new WaitForSeconds(delay);
    //     StartObstacle();
    // }
    //

    public void StartObstacle()
    {
        if (coroutine != null)
        {
            StopObstacle();
            ClearObstacle();
        }
        coroutine = StartCoroutine(GenerateObstacle());
    }

    public void StopObstacle()
    {
        StopCoroutine(coroutine);
        coroutine=null;
        foreach (var obstacle in obstaclePool)
        {
            obstacle.Stop();
        }
    }
    
    public void ClearObstacle()
    {
        foreach (var obstacle in obstaclePool)
        {
            ObjectPoolManager.Instance.Release( obstacle);
        }
        obstaclePool.Clear();
    }
    private IEnumerator GenerateObstacle()
    {
        while (true)
        {

            var newObstacle = ObjectPoolManager.Instance.Get(obstacle);
            newObstacle.transform.position = new Vector3(startX, Random.Range(minY, maxY), 0f);
            newObstacle.Init( _stateManager);
            var tween = newObstacle.Move(endX, duration);
            obstaclePool.Add(newObstacle);
            tween.OnComplete(() =>
            {
                obstaclePool.Remove(newObstacle);
                ObjectPoolManager.Instance.Release( newObstacle);
            });
            yield return wait;

        }
    }
    
    
}
