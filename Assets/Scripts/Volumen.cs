using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    [SerializeField] Slider barra_volumen;

    void Start()
    {
        if (!PlayerPrefs.HasKey("volumen"))
        {
            PlayerPrefs.SetFloat("volumen", 0.1f);
            cargar();
        }
        else
        {
            cargar();
        }
    }

    public void cambiar_volumen()
    {
        AudioListener.volume = barra_volumen.value;
        guardar();
    }

    private void cargar()
    {
        barra_volumen.value = PlayerPrefs.GetFloat("volumen");
    }

    private void guardar()
    {
        PlayerPrefs.SetFloat("volumen", barra_volumen.value);
    }
}
