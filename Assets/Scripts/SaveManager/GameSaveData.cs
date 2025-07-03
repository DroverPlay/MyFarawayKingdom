using System;

[Serializable]
public class GameSaveData
{
    // �������� �������
    public int money;
    public int foodCount;
    public int funCount;
    public int healthCount;
    public int flappyScore;
    public float multipleMoney;
    public bool gameExists;
    public bool musicOn;

    // ��������� ���������� ��������
    public int dropHealth;
    public int dropFood;
    public int dropFun;

    // �������� ����������
    public float foodDrainSpeed;
    public float funDrainSpeed;
    public float healthDrainSpeed;

    // ��������� ���������
    public int costFoodSpeedUpgrade;
    public int costFoodRateUpgrade;
    public int costFunSpeedUpgrade;
    public int costFunRateUpgrade;
    public int costHealthSpeedUpgrade;
    public int costHealthRateUpgrade;

    // ���������
    public float volumeLevel;
    public float prevVolumeLevel;
}
