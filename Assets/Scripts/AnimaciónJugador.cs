using UnityEngine;

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
    }

    void Update()
    {
        arriba_abajo();

        corazón();
        cambiar_color(1f);

        burbuja();
        if (contar == true)
        {
            activar_colisionador(10);
        }
    }

    private void arriba_abajo()
    {
        jugador.SetBool("Subir", Input.GetKey("up"));
        jugador.SetBool("Bajar", Input.GetKey("down"));
    }

    private void daño(int valor_daño)
    {
        PlayerPrefs.SetInt("vida", PlayerPrefs.GetInt("vida") - valor_daño);
    }

    void OnTriggerEnter2D(Collider2D colisión)
    {
        
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

    private void burbuja()
    {
        if (PlayerPrefs.GetInt("burbujas") > 0 & Input.GetKeyDown(KeyCode.B))
        {
            PlayerPrefs.SetInt("burbujas", PlayerPrefs.GetInt("burbujas") - 1);
            GetComponent<CircleCollider2D>().enabled = false;
            gameObject.transform.Find("Polvo").gameObject.SetActive(false);
            gameObject.transform.Find("Burbuja").gameObject.SetActive(true);
            instante_inicial_b = Time.time;
            contar = true;
        }
    }

    private void activar_colisionador(float segundos)
    {
        if (Time.time - instante_inicial_b >= segundos)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            gameObject.transform.Find("Polvo").gameObject.SetActive(true);
            gameObject.transform.Find("Burbuja").gameObject.SetActive(false);
            contar = false;
        }
    }
}
