using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Объявляем enum для типов меню
public enum MenuType
{
    None,
    Fun,
    Med,
    Shop,
    Food,
    Game,
    Category
}

// Объявляем класс MenuItem ДО основного класса
[System.Serializable]
public class MenuItem
{
    public MenuType type;
    public GameObject menuObject;
}

public class MenuManager : MonoBehaviour
{
    [Header("Настройки меню")]
    [SerializeField] private MenuItem[] menus;
    [SerializeField] private float menuTransitionDelay = 0.2f;

    private MenuType currentOpenMenu = MenuType.None;
    private GameObject currentCategory = null;
    private bool isTransitioning = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
        CloseAllMenus();
    }

    // Основной метод переключения меню
    public void ToggleMenu(MenuType menuType)
    {
        if (isTransitioning) return;

        if (currentOpenMenu == menuType)
        {
            CloseCurrentMenu();
            return;
        }

        StartCoroutine(SwitchMenuRoutine(menuType));
    }

    // Метод для открытия категорий
    public void OpenCategory(GameObject category)
    {
        if (isTransitioning) return;

        StartCoroutine(SwitchToCategoryRoutine(category));
    }

    private IEnumerator SwitchMenuRoutine(MenuType newMenu)
    {
        isTransitioning = true;
        CloseCurrentMenu();

        yield return new WaitForSeconds(menuTransitionDelay);

        OpenMenu(newMenu);
        isTransitioning = false;
    }

    private IEnumerator SwitchToCategoryRoutine(GameObject category)
    {
        isTransitioning = true;
        CloseCurrentMenu();

        yield return new WaitForSeconds(menuTransitionDelay);

        currentCategory = category;
        currentOpenMenu = MenuType.Category;
        category.SetActive(true);
        isTransitioning = false;
    }

    private void OpenMenu(MenuType menuType)
    {
        foreach (var menu in menus)
        {
            if (menu.type == menuType)
            {
                menu.menuObject.SetActive(true);
                currentOpenMenu = menuType;
                return;
            }
        }
    }

    private void CloseCurrentMenu()
    {
        if (currentOpenMenu == MenuType.Category && currentCategory != null)
        {
            currentCategory.SetActive(false);
        }
        else
        {
            foreach (var menu in menus)
            {
                if (menu.type == currentOpenMenu)
                {
                    menu.menuObject.SetActive(false);
                    break;
                }
            }
        }

        currentOpenMenu = MenuType.None;
        currentCategory = null;
    }

    private void CloseAllMenus()
    {
        foreach (var menu in menus)
        {
            menu.menuObject.SetActive(false);
        }

        if (currentCategory != null)
        {
            currentCategory.SetActive(false);
        }

        currentOpenMenu = MenuType.None;
        currentCategory = null;
    }

    public void OpenFunMenu() => ToggleMenu(MenuType.Fun);
    public void OpenMedMenu() => ToggleMenu(MenuType.Med);
    public void OpenShopMenu() => ToggleMenu(MenuType.Shop);
    public void OpenFoodMenu() => ToggleMenu(MenuType.Food);
    public void OpenGameMenu() => ToggleMenu(MenuType.Game);
}