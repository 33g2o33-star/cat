using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] private GameObject chapt;
    private Collider2D col;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat") && Chap2Quest.instance.nextchap)
        {
            gameObject.GetComponent<QuestClear>().cuCheck = true;
        }
    }
    private void Update()
    {
        if (chapt.activeSelf)
        {
            if (Chap2Quest.instance.nextchap)
            {
                col.isTrigger = false;
            }
        }
    }
}
