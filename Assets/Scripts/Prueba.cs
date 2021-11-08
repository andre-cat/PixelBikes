using UnityEngine;

public class Prueba : MonoBehaviour
{
    public int limones = 5;
    public int corazones = 5;
    public int burbujas = 5;

    void Start()
    {
        PlayerPrefs.SetInt("limones", limones);
        PlayerPrefs.SetInt("corazones", corazones);
        PlayerPrefs.SetInt("burbujas", burbujas);
    }
}
