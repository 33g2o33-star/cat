using UnityEngine;

public class Open : MonoBehaviour
{
    private Collider2D col;
    private void OnEnable()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = false;
    }
}
