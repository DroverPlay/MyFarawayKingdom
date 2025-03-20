using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    NeedsManager NeedsManagers;
    [Header("Настройки меню")]
    [SerializeField] string sceneName;


    private void Start()
    {
        NeedsManagers = FindObjectOfType<NeedsManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
        //NeedsManagers.Load();
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
        //NeedsManagers.Save();
    }
}
