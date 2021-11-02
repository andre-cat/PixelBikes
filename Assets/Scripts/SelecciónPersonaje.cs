using UnityEngine;
using TMPro;

public class SelecciónPersonaje : MonoBehaviour
{
    public ContenedorPersonaje personajes;

    public SpriteRenderer avatar;
    public TMP_Text nombre;
    public GameObject objeto;

    private int selección = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Avatar"))
        {
            selección = 0;
        }
        else
        {
            obtener_selección();
        }
        actualizar_selección(selección);
    }

    public void elegir_siguiente()
    {
        selección++;
        if (selección >= personajes.número_personajes)
        {
            selección = 0;
        }
        actualizar_selección(selección);
        guardar_selección();
    }

    public void elegir_anterior()
    {
        selección--;

        if (selección < 0)
        {
            selección = personajes.número_personajes - 1;
        }
        actualizar_selección(selección);
        guardar_selección();
    }

    private void obtener_selección()
    {
        selección = PlayerPrefs.GetInt("Avatar");
    }

    private void actualizar_selección(int selección)
    {
        Personaje personaje = personajes.obtener_personaje(selección);
        avatar.sprite = personaje.avatar;
        nombre.text = personaje.nombre;
        objeto = personaje.objeto;
    }

    private void guardar_selección()
    {
        PlayerPrefs.SetInt("Avatar", selección);
    }
}
