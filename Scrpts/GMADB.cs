using UnityEngine;

public class GMADB : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rigi;
    private Vector2 myori;
    private void OnEnable()
    {
        myori = transform.position;
        col = GetComponent<Collider2D>();
        col.isTrigger = false;
        rigi = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigi.linearVelocity = Vector3.left * 4;
        if (transform.position.y < myori.y)
        {
            this.enabled = false;
        }
    }
}
