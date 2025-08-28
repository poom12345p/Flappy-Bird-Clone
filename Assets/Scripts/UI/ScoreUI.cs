using PrimeTween;
using TMPro;
using UnityEngine;

public class ScoreUI : BaseUI
{
    public TMP_Text ScoreText=>_scoreText;
    [SerializeField]private TMP_Text _scoreText;
    [SerializeField]private TMP_Text _TapText;
    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }
    
    public void HideTapText()
    {
        Tween.Alpha(_TapText, 0f, 1f);
    }
}
