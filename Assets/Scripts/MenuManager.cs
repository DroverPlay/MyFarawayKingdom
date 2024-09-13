using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Основы")]
    [SerializeField] GameObject funMenu;
    [SerializeField] GameObject medMenu;
    [SerializeField] GameObject shopMenu;
    [SerializeField] GameObject foodMenu;
    [SerializeField] GameObject gameMenu;

    bool isOpenFun = false;
    bool isOpenMed = false;
    bool isOpenShop = false;
    bool isOpenFood = false;
    bool isOpenGame = false;
    bool isOpenCategory = false;
    private GameObject Category = null;

    private void Start()
    {
        Application.targetFrameRate = 60;
        funMenu.SetActive(isOpenFun);
        medMenu.SetActive(isOpenMed);
        shopMenu.SetActive(isOpenShop);
        foodMenu.SetActive(isOpenFood);
        gameMenu.SetActive(isOpenGame);
    }

    private void CloseAll()
    {
        funMenu.SetActive(false);
        isOpenFun = false;
        medMenu.SetActive(false);
        isOpenMed = false;
        shopMenu.SetActive(false);
        isOpenShop = false;
        foodMenu.SetActive(false);
        isOpenFood = false;
        gameMenu.SetActive(false);
        isOpenGame = false;
        if (isOpenCategory)
        {
            isOpenCategory = false;
            Category.SetActive(false);
        }
    }

    public void OpenFunMenu()
    {
        if (isOpenMed || isOpenShop || isOpenFood || isOpenGame || isOpenCategory)
        {
            CloseAll();
        }
        isOpenFun = !isOpenFun;
        funMenu.SetActive(isOpenFun);
    }

    public void OpenMedMenu()
    {
        if (isOpenFun || isOpenShop || isOpenFood || isOpenGame || isOpenCategory)
        {
            CloseAll();
        }
        isOpenMed = !isOpenMed;
        medMenu.SetActive(isOpenMed);
    }

    public void OpenShopMenu()
    {
        if (isOpenFun || isOpenMed || isOpenFood || isOpenGame || isOpenCategory)
        {
            CloseAll();
        }
        isOpenShop = !isOpenShop;
        shopMenu.SetActive(isOpenShop);
    }

    public void OpenFoodMenu()
    {
        if (isOpenFun || isOpenShop || isOpenMed || isOpenGame || isOpenCategory)
        {
            CloseAll();
        }
        isOpenFood = !isOpenFood;
        foodMenu.SetActive(isOpenFood);
    }

    public void OpenGameMenu()
    {
        if (isOpenFun || isOpenShop || isOpenFood || isOpenMed || isOpenCategory)
        {
            CloseAll();
        }
        isOpenGame = !isOpenGame;
        gameMenu.SetActive(isOpenGame);
    }
    
    public void OpenShopCategory(GameObject _Category)
    {
        if (isOpenFun || isOpenShop || isOpenFood || isOpenMed || isOpenGame)
        {
            CloseAll();
        }
        isOpenCategory = true;
        _Category.SetActive(isOpenCategory);
        Category = _Category;
    }

    public void openGame(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    //public void CloseGame()
    //{

    //}
}
