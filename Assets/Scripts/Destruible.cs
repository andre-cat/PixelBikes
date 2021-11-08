using UnityEngine;

public class Destruible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colisión)
    {
        Animator animador = GetComponent<Animator>();
        if (colisión.gameObject.tag == "Player")
        {
            if (name == "AceiteGrande" | name == "AceitePequeño")
            {
                animador.SetTrigger("Choque");
            }
            else
            {
                animador.SetBool("Choque", true);
            }
        }
    }

    void Update()
    {
        if (transform.position.x + GetComponentInChildren<SpriteRenderer>().bounds.size.x < Camera.main.ScreenToWorldPoint(Vector2.zero).x)
        {
            reiniciar();
        }
    }

    private void reiniciar()
    {
        if (gameObject.name != "AceiteGrande" & gameObject.name != "AceitePequeño")
        {
            GetComponent<Animator>().SetBool("Choque", false);
        }
    }
}
