using UnityEngine;

public class Desaparecer : MonoBehaviour
{
  
    private void Update()
    {
        if (GetComponent<SpriteRenderer>().enabled == false)
        {
            if (transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x < Camera.main.ScreenToWorldPoint(Vector2.zero).x)
            {
               this.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D colisión)
    {
        if (colisión.tag == "Player")
        {
           Animator animador = GetComponent<Animator>();
            animador.SetTrigger("Choque");
        }
    }

    private void invisible(){
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
}
