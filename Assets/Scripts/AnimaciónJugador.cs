using UnityEngine;
using System.Collections;

public class AnimaciónJugador : MonoBehaviour
{
    private Animator jugador;
    private Animator enemigo;
    public SpriteRenderer sprite;
    private bool color_blanco = false;
    private bool color_rojo = false;
    private float instante_inicial_v;
    private float instante_inicial_b;
    public Color color;
    private bool contar = false;

    void Awake()
    {
        jugador = GetComponent<Animator>();
        enemigo = GameObject.FindWithTag("Enemigo").GetComponent<Animator>();
        Texto.limones = PlayerPrefs.GetInt("limones", 0);
    }

    void Update()
    {
        arriba_abajo();
        corazón();
        cambiar_color(1f);
        burbuja();
        activar_colisionador(20);
    }

    private void arriba_abajo()
    {
        jugador.SetBool("Subir", Input.GetKey("up"));
        jugador.SetBool("Bajar", Input.GetKey("down"));
    }

    private void corazón()
    {
        if (PlayerPrefs.GetInt("corazones") > 0 & Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.SetInt("corazones", PlayerPrefs.GetInt("corazones") - 1);
            PlayerPrefs.SetInt("vida", 100);
            instante_inicial_v = Time.time;
            color_blanco = true;
        }
    }

    private void burbuja()
    {
        if (PlayerPrefs.GetInt("burbujas") > 0 & Input.GetKeyDown(KeyCode.B))
        {
            PlayerPrefs.SetInt("burbujas", PlayerPrefs.GetInt("burbujas") - 1);
            GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindWithTag("Polvo").SetActive(false);
            GameObject.FindWithTag("Burbuja").GetComponent<SpriteRenderer>().enabled = true;
            instante_inicial_b = Time.time;
            contar = true;
        }
    }

    private void daño(int valor_daño)
    {
        PlayerPrefs.SetInt("vida", PlayerPrefs.GetInt("vida") - valor_daño);
    }

    void OnTriggerEnter2D(Collider2D colisión)
    {
        switch (colisión.tag)
        {
            case "Limón":
                colisión.GetComponent<Animator>().SetTrigger("Choque");
                Texto.limones++;
                break;
            case "Destructible-Ofensivo":
                if (colisión.name == "Barril")
                {
                    jugador.SetTrigger("Resbalar");
                    enemigo.SetTrigger("Risa");
                    daño(30);
                }
                else
                {
                    jugador.SetTrigger("Contacto");
                    daño(10);
                }
                break;
            case "Indestructible-Ofensivo":
                jugador.SetTrigger("Resbalar");
                enemigo.SetTrigger("Risa");
                daño(20);
                break;
            case "Rampa":
                jugador.SetTrigger("Saltar");
                break;
        }
    }

    private void cambiar_color(float segundos)
    {
        if (color_blanco == true)
        {
            float completado = (Time.time - instante_inicial_v) / segundos;
            sprite.color = Color.Lerp(Color.white, color, completado);

            if (Time.time - instante_inicial_v >= segundos)
            {
                color_blanco = false;
                color_rojo = true;
                instante_inicial_v = Time.time;
            }
        }
        else if (color_rojo == true)
        {
            float completado = (Time.time - instante_inicial_v) / segundos;
            sprite.color = Color.Lerp(color, Color.white, completado);

            if (Time.time - instante_inicial_v >= segundos)
            {
                color_rojo = false;
            }
        }
    }

    private void activar_colisionador(float segundos)
    {
        if (contar == true)
        {
            if (Time.time - instante_inicial_b >= segundos)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                GameObject.FindWithTag("Burbuja").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindWithTag("Polvo").SetActive(true);
                contar = false;
            }
        }
    }
}
