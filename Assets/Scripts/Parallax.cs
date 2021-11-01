using UnityEngine;

public class Parallax : MonoBehaviour
{
    // xot is called before the first frame update
    private float longitud, limite_inferior_camara, limite_superior_camara, coordenada_final;
    public float Efecto_Parallax;
    public float retorno;

    void Start()
    {
        // Longitud del fondo.
        longitud = GetComponent<SpriteRenderer>().bounds.size.x;

        float distancia = Mathf.Abs(Camera.main.ScreenToWorldPoint(Vector2.zero).x - Camera.main.transform.position.x);

        limite_inferior_camara = Camera.main.ScreenToWorldPoint(Vector2.zero).x;
        limite_superior_camara = Camera.main.transform.position.x + distancia;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        {
            efecto_parallax();
        }
    }

    void efecto_parallax(){
            float resta = -Efecto_Parallax * Time.deltaTime * Controlador.factor();
        transform.position = new Vector3(transform.position.x + resta, transform.position.y, transform.position.z);

        coordenada_final = transform.position.x + longitud; // Coordenada del límite derecho del objeto

        if (coordenada_final <= limite_inferior_camara)
        {
            transform.position = new Vector3(retorno, transform.position.y, transform.position.z);
        }
    }
}
