using UnityEngine;

public class InstánciameAquí : MonoBehaviour
{
    public ContenedorPersonaje contenedor;

    private void Start()
    {
        GameObject objeto = contenedor.obtener_personaje(PlayerPrefs.GetInt("Avatar")).objeto;
        objeto = Instantiate(objeto, this.transform.position, Quaternion.identity,this.transform);
    }
}
