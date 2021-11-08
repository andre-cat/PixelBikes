using UnityEngine;

public class Visibilidad : MonoBehaviour
{

    private void invisible()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void visible()
    {
        if (transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x < Camera.main.ScreenToWorldPoint(Vector2.zero).x)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void Update()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            visible();
        }
    }
}
