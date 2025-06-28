public class SaveData
{
    private static int saveMoney;
    private static int saveFoodCount;
    private static int saveFunCount;
    private static int saveHealthCount;

    private static int saveFlappyScore;

    private static float saveMultipleMoney;

    private static bool saveGameExists;

    private static int saveDropHelth;
    private static int saveDropFood;
    private static int saveDropFun;

    private static float saveFoodDrainSpeed;

    //Сохранение стоимости улучшений
    private static int saveCostFoodSpeedUpgrade;
    private static int saveCostFoodRateUpgrade;

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
    public static int dropHelth
    {
        get { return saveDropHelth; }
        set { saveDropHelth = value; }
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
}
