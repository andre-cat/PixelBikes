using UnityEngine;

public class AnimaciónObstáculo : MonoBehaviour
{
    public Obstáculo obstáculo;

    void Awake()
    {
        obstáculo = GetComponent<Obstáculo>();
    }

    void OnTriggerEnter2D(Collider2D colisionador)
    {
        if (colisionador.tag == "Player")
        {
            switch (obstáculo.destruible)
            {
                case Obstáculo.Destruible.Sí:
                    if (obstáculo.nombre == "aceite")
                    {
                        GetComponent<Animator>().SetTrigger("Choque");
                    }
                    else
                    {
                        GetComponent<Animator>().SetBool("Choque", true);
                        if (obstáculo.nombre != "rampa")
                        {
                            gameObject.transform.Find("Efecto").GetComponent<Animator>().SetTrigger("Choque");
                        }
                    }
                    break;
            }
        }
    }

    void Update()
    {
        if (obstáculo.destruible == Obstáculo.Destruible.Sí & obstáculo.nombre != "aceite")
        {
            if (transform.position.x + GetComponentInChildren<SpriteRenderer>().bounds.size.x < Camera.main.ScreenToWorldPoint(Vector2.zero).x)
            {
                GetComponent<Animator>().SetBool("Choque", false);
            }
        }
    }
}
