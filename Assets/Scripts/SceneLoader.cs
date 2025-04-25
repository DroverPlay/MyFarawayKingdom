using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        SaveData.multipleMoney = 1;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}