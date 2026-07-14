using UnityEngine;

public class Reduce : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.attachedRigidbody.gravityScale = 1.7f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.attachedRigidbody.gravityScale = 3f;
    }
}
