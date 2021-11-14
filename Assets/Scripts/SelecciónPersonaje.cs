using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelecciónPersonaje : MonoBehaviour
{
    public enum TipoAnimación
    {
        Transición,
        GameOver,
    }

    public ContenedorPersonajes personajes;

    public GameObject objeto;
    public TMP_Text nombre;
    public SpriteRenderer avatar;
    public Image fondo;
    public TMP_Text título;
    public GameObject animación;
    public TipoAnimación tipo_animación;

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
        if (selección >= personajes.número)
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
            selección = personajes.número - 1;
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
        Personaje personaje = personajes.personaje(selección);

        if (avatar != null)
        {
            avatar.sprite = personaje.avatar;
        }

        if (nombre != null)
        {
            nombre.text = personaje.nombre;
        }

        if (fondo != null)
        {
            fondo.color = new Color(personaje.fondo.r, personaje.fondo.g, personaje.fondo.b, 1);
        }

        if (título != null)
        {
            título.color = new Color(personaje.título.r, personaje.título.g, personaje.título.b, 1);
        }

        if (animación != null)
        {
            animación.GetComponent<Image>().enabled = false;
            if (tipo_animación == TipoAnimación.Transición)
            {
                GameObject transición = Instantiate(personaje.transición, animación.transform.position, Quaternion.identity, animación.transform);
            }
            else
            {
                GameObject muerte = Instantiate(personaje.muerte, animación.transform.position, Quaternion.identity, animación.transform);
            }
        }

        if (objeto != null){
            GameObject objeto_juego = Instantiate(personaje.objeto, objeto.transform.position, Quaternion.identity, objeto.transform);
        }
    }

    private void guardar_selección()
    {
        PlayerPrefs.SetInt("Avatar", selección);
    }
}
