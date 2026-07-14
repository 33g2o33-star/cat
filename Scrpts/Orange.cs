using UnityEngine;

public class Orange : MonoBehaviour
{
    private Rigidbody2D rigi;
    private Collider2D col;
    private void OnEnable()
    {
        if (gameObject.GetComponent<Collider2D>().enabled)
        {
            col = GetComponent<Collider2D>();
            col.isTrigger = true;
        }
        if (gameObject.GetComponent<Rigidbody2D>())
        {
            rigi = GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            rigi.gravityScale = 0;
            col.isTrigger = true;
        }
    }

}
