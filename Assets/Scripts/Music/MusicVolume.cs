using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private Button volumeButton;
    [SerializeField] private AudioSource volumeSource;

    [Header("Теги")]
    [SerializeField] private string musicTag;
    [SerializeField] private string onOffTag;

    [Header("Изображения")]
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;

    private bool music = true;

    private void Awake()
    {
        volumeButton = GameObject.FindWithTag(this.onOffTag).GetComponent<Button>();
        volumeSource = GameObject.FindWithTag(this.musicTag).GetComponent<AudioSource>();

        if (volumeSource.volume == 0) { musicOff(); }
        else { musicOn(); }
    }
    public void MusicButton()
    {
        if (music) { musicOff(); }
        else if (music == false) { musicOn(); }
    }
    void musicOn()
    {
        music = true;
        volumeButton.GetComponent<Image>().sprite = onSprite;
        volumeSource.volume = 0.5f;
    }
    void musicOff()
    {
        music = false;
        volumeButton.GetComponent<Image>().sprite = offSprite;
        volumeSource.volume = 0;
    }
}