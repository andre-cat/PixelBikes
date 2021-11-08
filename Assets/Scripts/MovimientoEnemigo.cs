using UnityEngine;
using System.Collections;

public class MovimientoEnemigo : MonoBehaviour
{
    public static bool mitad;
    public static bool final;
    private float velocidad = 400;
    private Rigidbody2D enemigo;

    void Awake()
    {
        enemigo = GetComponent<Rigidbody2D>();
        mitad = false;
        final = false;
    }

    void FixedUpdate()
    {
        inicio();
    }

    private void inicio()
    {
        if (enemigo.transform.position.x < -50)
        {
            Vector2 dirección = new Vector2(+1, 0);
            enemigo.velocity = dirección * velocidad * Time.deltaTime * Controlador.factor();
        }
        else
        {
            enemigo.velocity = new Vector3(0, 0, 0);
            medio_tiempo();
        }
    }

    private void medio_tiempo()
    {
        if (mitad == true & enemigo.transform.position.x < 10)
        {
            Vector2 dirección = new Vector2(+1, 0);
            enemigo.velocity = dirección * velocidad * Time.deltaTime * Controlador.factor();
        }
        else
        {
            enemigo.velocity = new Vector3(0, 0, 0);
            fin();
        }
    }

    private void fin()
    {
        if (final == true & enemigo.transform.position.x < 100)
        {
            Vector2 dirección = new Vector2(+1, 0);
            enemigo.velocity = dirección * velocidad * Time.deltaTime * Controlador.factor();
        }
        else
        {
            enemigo.velocity = new Vector3(0, 0, 0);
        }
    }

    private void roca()
    {
        GameObject.FindWithTag("Roca").GetComponent<MovimientoObjeto>().enabled = true;
    }

    private void ganar()
    {
        PlayerPrefs.SetInt("limones", Texto.limones);
        PlayerPrefs.SetInt("nivel", PlayerPrefs.GetInt("nivel") + 1);
        PlayerPrefs.SetFloat("tiempo", PlayerPrefs.GetFloat("tiempo") + 30f);
        PlayerPrefs.SetFloat("dificultad", PlayerPrefs.GetFloat("dificultad") + 0.25f);
        if (PiscinaMúltiple.iniciar_en - 1 > 1)
        {
            PiscinaMúltiple.iniciar_en--;
        }
        FindObjectOfType<CargadorNivel>().trans();
    }
}
