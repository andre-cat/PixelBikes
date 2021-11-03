using UnityEngine;

public class Destruible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisión)
    {
        if (colisión.gameObject.tag == "Player")
        {
                 Animator animador = GetComponent<Animator>();
            if (name == "AceiteGrande" | name == "AceitePequeño")
            {
                animador.SetTrigger("Choque");
            }else{
                animador.SetBool("Choque", true);
            }
        }

    }
}
