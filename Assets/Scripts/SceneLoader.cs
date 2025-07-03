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
        if (SaveManager.Current.gameExists)
            if (_ContinueButton != null)
                _ContinueButton.SetActive(true);
    }
    public void StartNewGame()
    {
        if (SaveManager.Current.gameExists)
        {
            _Menu.SetActive(false);
            _AproveMenu.SetActive(true);
        }
        else
        {
            Debug.Log("Íîâàÿ èãðà");
            SceneManager.LoadScene("MainScene");
            SaveManager.Current.multipleMoney = 1;
            SaveManager.Current.foodCount = 22;
            SaveManager.Current.funCount = 22;
            SaveManager.Current.healthCount = 22;
            SaveManager.Current.money = 20000;
            SaveManager.Current.gameExists = true;
            SaveManager.Current.dropFood = 2;
            SaveManager.Current.dropHealth = 2;
            SaveManager.Current.dropFun = 2;
            SaveManager.Current.foodDrainSpeed = 15;
            SaveManager.Current.costFoodSpeedUpgrade = 100;
            SaveManager.Current.costFoodRateUpgrade = 1000;
            SaveManager.Current.funDrainSpeed = 15;
            SaveManager.Current.costFunSpeedUpgrade = 100;
            SaveManager.Current.costFunRateUpgrade = 1000;
            SaveManager.Current.healthDrainSpeed = 15;
            SaveManager.Current.costHealthSpeedUpgrade = 100;
            SaveManager.Current.costHealthRateUpgrade = 1000;
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
            SaveManager.Current.gameExists = false;
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
        SaveManager.Save();
        Application.Quit();
    }
}