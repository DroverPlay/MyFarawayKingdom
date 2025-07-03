using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private int _basicMultiple = 1;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _scoreText.text = _score.ToString();

        _bestScore.text = SaveManager.Current.flappyScore.ToString();

        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        if (_score > SaveManager.Current.flappyScore)
        {
            SaveManager.Current.flappyScore = _score;
            _bestScore.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
        MultipleMoney();
        UpdateBestScore();
        SaveManager.Current.money += _basicMultiple;
    }

    private void MultipleMoney()
    {
        if (_score > 5)
            _basicMultiple = 2;
        else if (_score > 10)
            _basicMultiple = 3;
        else if (_score > 15)
            _basicMultiple = 4;
        else if (_score > 20)
            _basicMultiple = 5;
    }
}
