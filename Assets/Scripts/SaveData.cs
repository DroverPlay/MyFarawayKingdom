public class SaveData
{
    private static int saveMoney;
    private static int saveFoodCount;
    private static int saveFunCount;
    private static int saveHealthCount;

    private static int saveFlappyScore;

    private static float saveMultipleMoney;

    private static bool saveGameExists;

    private static int saveDropHealth;
    private static int saveDropFood;
    private static int saveDropFun;

    private static float saveFoodDrainSpeed;
    private static float saveFunDrainSpeed;
    private static float saveHealthDrainSpeed;

    //Сохранение стоимости улучшений
    private static int saveCostFoodSpeedUpgrade;
    private static int saveCostFoodRateUpgrade;

    private static int saveCostFunSpeedUpgrade;
    private static int saveCostFunRateUpgrade;

    private static int saveCostHealthSpeedUpgrade;
    private static int saveCostHealthRateUpgrade;

    public static int money
    {
        get { return saveMoney; }
        set { saveMoney = value; }
    }
    public static int foodCount
    {
        get { return saveFoodCount; }
        set { saveFoodCount = value; }
    }
    public static int funCount
    {
        get { return saveFunCount; }
        set { saveFunCount = value; }
    }
    public static int healthCount
    {
        get { return saveHealthCount; }
        set { saveHealthCount = value; }
    }
    public static int flappyScore
    {
        get { return saveFlappyScore; }
        set { saveFlappyScore = value; }
    }
    public static float multipleMoney
    {
        get { return saveMultipleMoney; }
        set { saveMultipleMoney = value; }
    }
    public static bool gameExists
    {
        get { return saveGameExists; }
        set { saveGameExists = value; }
    }
    public static int dropHealth
    {
        get { return saveDropHealth; }
        set { saveDropHealth = value; }
    }
    public static int dropFun
    {
        get { return saveDropFun; }
        set { saveDropFun = value; }
    }
    public static int dropFood
    {
        get { return saveDropFood; }
        set { saveDropFood = value; }
    }
    //Еда
    public static float drainFoodSpeedCount
    {
        get { return saveFoodDrainSpeed; }
        set { saveFoodDrainSpeed = value; }
    }
    public static int CostFoodSpeedUpgrade
    {
        get { return saveCostFoodSpeedUpgrade; }
        set { saveCostFoodSpeedUpgrade = value; }
    }
    public static int CostFoodRateUpgrade
    {
        get { return saveCostFoodRateUpgrade; }
        set { saveCostFoodRateUpgrade = value; }
    }
    //Настроение
    public static float drainFunSpeedCount
    {
        get { return saveFunDrainSpeed; }
        set { saveFunDrainSpeed = value; }
    }
    public static int CostFunSpeedUpgrade
    {
        get { return saveCostFunSpeedUpgrade; }
        set { saveCostFunSpeedUpgrade = value; }
    }
    public static int CostFunRateUpgrade
    {
        get { return saveCostFunRateUpgrade; }
        set { saveCostFunRateUpgrade = value; }
    }
    //Здоровье
    public static float drainHealthSpeedCount
    {
        get { return saveHealthDrainSpeed; }
        set { saveHealthDrainSpeed = value; }
    }
    public static int CostHealthSpeedUpgrade
    {
        get { return saveCostHealthSpeedUpgrade; }
        set { saveCostHealthSpeedUpgrade = value; }
    }
    public static int CostHealthRateUpgrade
    {
        get { return saveCostHealthRateUpgrade; }
        set { saveCostHealthRateUpgrade = value; }
    }
}
