using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;

    private static GameManager instance;

    public Vector3 playerJoinPosition;
  
    






    #region Buttons
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
      
    }
    public void GameWin()
    {
        gameWinScreen.SetActive(true);

    }
   
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SlowGame()
    {
        Time.timeScale = 0f;
    }

    public void Discord ()
    {
        Application.OpenURL("https://discord.gg/QswUu4");
    }
    public void Youtube ()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCgC_d3SnmrmR6KEuq-LKt0g?sub_confirmation=1");
    }
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/Minidevs1");
    }
	#endregion

}
