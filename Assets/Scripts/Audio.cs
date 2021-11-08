using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio música;
    public AudioSource fuente_audio;

    void Awake()
    {
        if (música == null)
        {
            Audio.música = this;
            DontDestroyOnLoad(gameObject);
            fuente_audio = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        fuente_audio.volume = PlayerPrefs.GetFloat("volumen", 0.1f);
    }
}
