using System.Collections;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private int count = 0;
    private int a = 1;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat") && count == 0)
        {
            if (QuestManager.instance.Cat.dir.x > 0)
            {
                a = -1;
            }
            StartCoroutine(Falling());
            count++;
        }
    }

    IEnumerator Falling()
    {
        for (int i = 0; i <= 90; i += 10)
        {
            transform.rotation = Quaternion.Euler(0, 0, i * a);
            transform.position = new Vector3(transform.position.x - (a * 0.2f), transform.position.y, 0);
            yield return new WaitForSeconds(0.01f);
            if (gameObject.GetComponent<QuestClear>() != null)
            {
                gameObject.GetComponent<QuestClear>().cuCheck = true;
            }
            else
            {

            }

        }
        QuestManager.instance.trash = true;
    }
}
