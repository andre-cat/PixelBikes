using UnityEngine;
using TMPro;

public class InstánciameAquí : MonoBehaviour
{
    public ContenedorObjetos jugadores;

    void Start()
    {
        GameObject objeto = jugadores.objeto(PlayerPrefs.GetInt("Avatar"));
        objeto = Instantiate(objeto, this.transform.position, Quaternion.identity, this.transform);
    }
}