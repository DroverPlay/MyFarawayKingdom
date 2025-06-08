using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);

        Time.timeScale = 0f;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
