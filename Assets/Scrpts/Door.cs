using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D col;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (Chap3Quest.instance.questStack >= 3)
        {
            col.isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            gameObject.GetComponent<QuestClear>().cuCheck = true;
        }
    }
}
