using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RealWall : MonoBehaviour
{
    private SpriteRenderer spr;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat") && gameObject.activeSelf)
        {
            Color color = spr.color;
            color.a = 1;
            StartCoroutine(FadeOut());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat") && gameObject.activeSelf)
        {
            Color color = spr.color;
            color.a = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            Color color = spr.color;
            color.a = 0;
            StartCoroutine(FadeIn());
        }
    }
    IEnumerator FadeIn()
    {
        Color color = spr.color;
        while (color.a > 0)
        {
            color.a -= 0.1f;
            spr.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeOut()
    {
        Color color = spr.color;
        while (color.a <= 1)
        {
            color.a += 0.1f;
            spr.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
