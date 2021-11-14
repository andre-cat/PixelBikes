using UnityEngine;
using TMPro;

public class Texto : MonoBehaviour
{
    public static int limones;

    public enum TipoConteo
    {
        Limones,
        Burbujas,
        Corazones,
        Nivel,
    }

    public TipoConteo conteo;
    private TMP_Text texto;

    private void Awake()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        switch (conteo)
        {
            case TipoConteo.Limones:
                if (Controlador.over == false)
                {
                    texto.text = limones.ToString();
                }
                break;
            case TipoConteo.Burbujas:
                texto.text = PlayerPrefs.GetInt("burbujas", 0).ToString();
                break;
            case TipoConteo.Corazones:
                texto.text = PlayerPrefs.GetInt("corazones", 0).ToString();
                break;
            case TipoConteo.Nivel:
                texto.text = "Nivel " + PlayerPrefs.GetInt("nivel", 1).ToString();
                break;
        }
    }
}
