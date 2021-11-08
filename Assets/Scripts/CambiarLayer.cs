using UnityEngine;

public class CambiarLayer : MonoBehaviour
{
    public int layer;

    void OnTriggerStay2D(Collider2D colisión)
    {
        if (colisión.tag == "Player")
        {
            colisión.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = layer;
        }
    }
}
