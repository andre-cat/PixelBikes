using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    [SerializeField] Slider barra_volumen;

    void Start()
    {
        barra_volumen.value = PlayerPrefs.GetFloat("volumen");
    }

    void update()
    {
        cambiar_volumen();
    }

    public void cambiar_volumen()
    {
        Música.fuente_audio.volume = barra_volumen.value;
        PlayerPrefs.SetFloat("volumen",barra_volumen.value);
    }
}
