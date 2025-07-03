using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private Button volumeButton;
    [SerializeField] private AudioSource volumeSource;
    [SerializeField] private Slider volumeSlider;

    [Header("Теги")]
    [SerializeField] private string musicTag;
    [SerializeField] private string onOffTag;

    [Header("Изображения")]
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;

    private bool music;

    private void Awake()
    {
        music = SaveManager.Current.musicOn;
        volumeButton = GameObject.FindWithTag(this.onOffTag).GetComponent<Button>();
        GameObject obj = GameObject.FindWithTag(musicTag);
        if (obj != null) volumeSource = obj.GetComponent<AudioSource>();

        if (volumeSource.volume == 0) { musicOff(); }
        else { musicOn(); }
        if (SaveManager.Current.volumeLevel != 0 && SaveManager.Current.volumeLevel != null)
        {
            volumeSlider.value = SaveManager.Current.volumeLevel;
            volumeSource.volume = volumeSlider.value;
        }
    }
    public void MusicButton()
    {
        music = SaveManager.Current.musicOn;
        Debug.Log("Текущее значение музыки: " + music);
        if (music == true) { musicOff(); Debug.Log("музик офф"); return; }
        if (music == false) { musicOn(); Debug.Log("музик он"); }
    }
    void musicOn()
    {
        music = true;
        SaveManager.Current.musicOn = music;
        volumeButton.GetComponent<Image>().sprite = onSprite;
        volumeSource.volume = 0.5f;
        volumeSlider.value = 0.5f;
        SaveManager.Current.volumeLevel = volumeSlider.value;

        if (SaveManager.Current.prevVolumeLevel != 0)
        {
            volumeSlider.value = SaveManager.Current.prevVolumeLevel;
            Debug.Log("Сохраненное предыдущее значение: " +  volumeSlider.value);
            SaveManager.Current.volumeLevel = volumeSlider.value;
            volumeSource.volume = volumeSlider.value;
        }
    }
    void musicOff()
    {
        music = false;
        SaveManager.Current.musicOn = music;
        volumeButton.GetComponent<Image>().sprite = offSprite;
        SaveManager.Current.prevVolumeLevel = volumeSlider.value;
        Debug.Log("Сохраненное предыдущее значение при выключении: " + volumeSlider.value);
        SaveManager.Current.volumeLevel = 0;
        volumeSource.volume = 0;
        volumeSlider.value = 0;
    }
    public void VolumeLevel()
    {
        float volume = volumeSlider.value;
        SaveManager.Current.volumeLevel = volume;

        Debug.Log(volume);
        if (volume == 0)
        {
            music = false;
            Debug.Log("музик офф от слайдера " + music);
            volumeButton.GetComponent<Image>().sprite = offSprite;
        }

        else
        {
            music = true;
            volumeButton.GetComponent<Image>().sprite = onSprite;
        }
        SaveManager.Current.musicOn = music;
        volumeSource.volume = volume;
    }
}