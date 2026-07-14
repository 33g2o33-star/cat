using UnityEngine;

public class Market : MonoBehaviour
{
    private Collider2D col;
    private Animator anim;
    private void Awake()
    {
        col = GetComponent<Collider2D>();    
        anim = GetComponent<Animator>();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            col.isTrigger = true;
            anim.SetBool("Col", true);
            Chap1Quest.instance.market = true;
        }
    }
}
