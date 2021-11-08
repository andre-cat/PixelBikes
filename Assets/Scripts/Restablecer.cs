using UnityEngine;

public class Restablecer : MonoBehaviour
{
    public void borrar_todo()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("dificultad", 0);
        PlayerPrefs.SetInt("limones", 0);
        PlayerPrefs.SetInt("corazones", 0);
        PlayerPrefs.SetInt("burbujas", 0);
    }
}
