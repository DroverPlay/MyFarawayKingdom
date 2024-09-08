using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Основы")]
    [SerializeField] GameObject funMenu;
    [SerializeField] GameObject medMenu;
    [SerializeField] GameObject shopMenu;
    [SerializeField] GameObject foodMenu;
    //[SerializeField] GameObject outsideMenu;

    bool isOpenFun = false;
    bool isOpenMed = false;
    bool isOpenShop = false;
    bool isOpenFood = false;
    bool isOpenOutside = false;
    bool isOpenCategory = false;
    private GameObject Category = null;

    private void Start()
    {
        Application.targetFrameRate = 30;
        funMenu.SetActive(isOpenFun);
        medMenu.SetActive(isOpenMed);
        shopMenu.SetActive(isOpenShop);
        foodMenu.SetActive(isOpenFood);
        //outsideMenu.SetActive(isOpenOutside);
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
        //outsideMenu.SetActive(false);
        isOpenOutside = false;
        if (isOpenCategory)
        {
            isOpenCategory = false;
            Category.SetActive(false);
        }
    }

    public void OpenFunMenu()
    {
        if (isOpenMed || isOpenShop || isOpenFood || isOpenOutside || isOpenCategory)
        {
            CloseAll();
        }
        isOpenFun = !isOpenFun;
        funMenu.SetActive(isOpenFun);
    }

    public void OpenMedMenu()
    {
        if (isOpenFun || isOpenShop || isOpenFood || isOpenOutside || isOpenCategory)
        {
            CloseAll();
        }
        isOpenMed = !isOpenMed;
        medMenu.SetActive(isOpenMed);
    }

    public void OpenShopMenu()
    {
        if (isOpenFun || isOpenMed || isOpenFood || isOpenOutside || isOpenCategory)
        {
            CloseAll();
        }
        isOpenShop = !isOpenShop;
        shopMenu.SetActive(isOpenShop);
    }

    public void OpenFoodMenu()
    {
        if (isOpenFun || isOpenShop || isOpenMed || isOpenOutside || isOpenCategory)
        {
            CloseAll();
        }
        isOpenFood = !isOpenFood;
        foodMenu.SetActive(isOpenFood);
    }

    public void OpenOutMenu()
    {
        if (isOpenFun || isOpenShop || isOpenFood || isOpenMed || isOpenCategory)
        {
            CloseAll();
        }
        isOpenOutside = !isOpenOutside;
        //outsideMenu.SetActive(isOpenOutside);
    }
    
    public void OpenShopCategory(GameObject _Category)
    {
        if (isOpenFun || isOpenShop || isOpenFood || isOpenMed || isOpenOutside)
        {
            CloseAll();
        }
        isOpenCategory = true;
        _Category.SetActive(isOpenCategory);
        Category = _Category;
    }

    //public void CloseGame()
    //{

    //}
}
