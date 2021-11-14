using UnityEngine;

public class Música : MonoBehaviour
{
    public static Música música;
    public static AudioSource fuente_audio;

    void Awake()
    {
        if (música == null)
        {
            Música.música = this;
            fuente_audio = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        fuente_audio.volume = PlayerPrefs.GetFloat("volumen",0.025f);
    }
}
