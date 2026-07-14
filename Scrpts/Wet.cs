using System.Collections;
using UnityEngine;

public class Wet : MonoBehaviour
{
    private bool wetPlace = false;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wet"))
        {
            wetPlace = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (wetPlace)
        {
            Hwabonnam.instance.kong = true;
        }
        if (collision.CompareTag("Floor") && wetPlace)
        {
            StartCoroutine(Kong());
            Hwabonnam.instance.anim.SetBool("Kong", true);
            Hwabonnam.instance.kong = false;
            wetPlace = false;
        }
    }

    IEnumerator Kong()
    {
        yield return new WaitForSeconds(3);
        Hwabonnam.instance.wakeUp = true;
        Hwabonnam.instance.anim.SetBool("Wakeup", true);
    }
}
