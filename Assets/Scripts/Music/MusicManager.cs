using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Теги")]
    [SerializeField] private string musicTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(this.musicTag);
        if (obj != null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            this.gameObject.tag = this.musicTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}