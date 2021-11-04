using UnityEngine;

public class Destruible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisión)
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

    private void Update()
    {
        reiniciar();
    }

    private void reiniciar()
    {
        if (transform.position.x + GetComponentInChildren<SpriteRenderer>().bounds.size.x < Camera.main.ScreenToWorldPoint(Vector2.zero).x)
        {
            if (gameObject.name != "AceiteGrande" & gameObject.name != "AceitePequeño")
            {
                GetComponent<Animator>().SetBool("Choque", false);
            }
        }
    }
}
