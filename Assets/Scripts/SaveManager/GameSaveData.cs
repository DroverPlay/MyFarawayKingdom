using System;

[Serializable]
public class GameSaveData
{
    // Основные ресурсы
    public int money;
    public int foodCount;
    public int funCount;
    public int healthCount;
    public int flappyScore;
    public float multipleMoney;
    public bool gameExists;
    public bool musicOn;

    // Параметры уменьшения значений
    public int dropHealth;
    public int dropFood;
    public int dropFun;

    // Скорости уменьшения
    public float foodDrainSpeed;
    public float funDrainSpeed;
    public float healthDrainSpeed;

    // Стоимости улучшений
    public int costFoodSpeedUpgrade;
    public int costFoodRateUpgrade;
    public int costFunSpeedUpgrade;
    public int costFunRateUpgrade;
    public int costHealthSpeedUpgrade;
    public int costHealthRateUpgrade;

    // Настройки
    public float volumeLevel;
    public float prevVolumeLevel;
}
