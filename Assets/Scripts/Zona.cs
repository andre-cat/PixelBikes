using UnityEngine;

public class Zona : MonoBehaviour
{

    public int layer;

    private void OnTriggerStay2D(Collider2D colisión)
    {
        if (colisión.gameObject.tag == "Player")
        {
            colisión.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = layer;
        }
    }
}
