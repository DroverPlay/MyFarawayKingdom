public class SaveData
{
    private static int saveMoney;
    private static int saveFoodCount;
    private static int saveFunCount;
    private static int saveHealthCount;

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
}
