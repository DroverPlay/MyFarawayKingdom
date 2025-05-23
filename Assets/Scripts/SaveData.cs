public class SaveData
{
    private static int saveMoney;
    private static int saveFoodCount;
    private static int saveFunCount;
    private static int saveHealthCount;

    private static int saveFlappyScore;

    private static float saveMultipleMoney;

    private static bool saveGameExists;

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
}
