using UnityEngine;

public class Restablecer : MonoBehaviour
{
    public void borrar_todo()
    {
        float volumen = PlayerPrefs.GetFloat("volumen");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("volumen",volumen);
        PlayerPrefs.SetFloat("dificultad", 0);
        PlayerPrefs.SetInt("limones", 0);
        PlayerPrefs.SetInt("corazones", 0);
        PlayerPrefs.SetInt("burbujas", 0);
    }
}
