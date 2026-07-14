using UnityEngine;

public class Wall : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] int limit;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (Chap1Quest.instance.questStack >= limit)
        {
            col.isTrigger = true;
        }
    }
}
