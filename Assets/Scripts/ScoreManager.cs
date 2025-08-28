using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int Score =>score;
    private int score=0;
    
    [SerializeField]private ScoreUI scoreUIPrefab;
    private ScoreUI _scoreUI;

    public void StartScore()
    {
        score = 0;
        _scoreUI.UpdateScore(score);
        _scoreUI.Show();
    }
    
    
    public void Init()
    {
        _scoreUI = Instantiate(scoreUIPrefab);
    }

    public void AddScore()
    {
        score++;
        _scoreUI.UpdateScore(score);
    }
    
    public void GameOver()
    {
        _scoreUI.Hide();
        GameManager.Instance.SaveScore(score);
    }
}
