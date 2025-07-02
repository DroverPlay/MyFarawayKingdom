using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ContinueButton;
    [SerializeField] private GameObject _Menu;
    [SerializeField] private GameObject _AproveMenu;
    [SerializeField] private GameObject _SettingsMenu;

    private bool _aprove = false;

    private void Start()
    {
        if (SaveData.gameExists)
            if (_ContinueButton != null)
                _ContinueButton.SetActive(true);
    }
    public void StartNewGame()
    {
        if (SaveData.gameExists)
        {
            _Menu.SetActive(false);
            _AproveMenu.SetActive(true);
        }
        else
        {
            Debug.Log("Íîâàÿ èãðà");
            SceneManager.LoadScene("MainScene");
            SaveData.multipleMoney = 1;
            SaveData.foodCount = 22;
            SaveData.funCount = 22;
            SaveData.healthCount = 22;
            SaveData.money = 20000;
            SaveData.gameExists = true;
            SaveData.dropFood = 2;
            SaveData.dropHealth = 2;
            SaveData.dropFun = 2;
            SaveData.drainFoodSpeedCount = 15;
            SaveData.CostFoodSpeedUpgrade = 100;
            SaveData.CostFoodRateUpgrade = 1000;
            SaveData.drainFunSpeedCount = 15;
            SaveData.CostFunSpeedUpgrade = 100;
            SaveData.CostFunRateUpgrade = 1000;
            SaveData.drainHealthSpeedCount = 15;
            SaveData.CostHealthSpeedUpgrade = 100;
            SaveData.CostHealthRateUpgrade = 1000;
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Àpprov(bool yes)
    {
        if (yes)
        {
            SaveData.gameExists = false;
            StartNewGame();
        }
        else
        {
            _AproveMenu.SetActive(false); 
            _Menu.SetActive(true);
        }
    }
    public void OpenSettings()
    {
        _SettingsMenu.SetActive(!_SettingsMenu.activeSelf);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}