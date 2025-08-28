using TMPro;
using UnityEngine;

public class ResultUI : BaseUI
{
   [SerializeField]private TMP_Text HighScore;
   [SerializeField]private TMP_Text Score;


   public override void Show()
   {
      base.Show();
   }

   public void SetScore(int score)
   {
      HighScore.text =GameManager.Instance.HighScore.ToString();
      Score.text = score.ToString();
   }
  
   public void Restart()
   {
      GameManager.Instance.StartGame();
   }
    
   public void GoToMainMenu()
   {
      GameManager.Instance.GoToMainMenu();
   }
   
}
