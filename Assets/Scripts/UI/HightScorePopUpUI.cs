using TMPro;
using UnityEngine;

public class HightScorePopUpUI : BaseUI
{
    [SerializeField]private TMP_Text HighScore;
    public override void Show()
    {
        base.Show();
        HighScore.text =GameManager.Instance.HighScore.ToString();
    }


}
