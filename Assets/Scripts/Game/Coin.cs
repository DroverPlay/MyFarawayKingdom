using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _money;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GiveMoney(_money);
        SceneManager.LoadScene("MainScene");
    }

    private void GiveMoney(int money)
    {
        SaveManager.Current.money += money;
    }
}
