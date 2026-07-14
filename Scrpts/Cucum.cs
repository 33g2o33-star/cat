using UnityEngine;

public class Cucum : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            QuestManager.instance.Cat.CucumJump();
            gameObject.GetComponent<QuestClear>().cuCheck = true;
        }
    }
}
