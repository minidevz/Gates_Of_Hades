using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject bookMenu;

    public void StartSequenceOfGame()
    {
        bookMenu.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Quit()
    {

        Application.Quit();
    }
}
