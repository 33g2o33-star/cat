using UnityEngine;

public class BreakItem : MonoBehaviour
{
    private AudioSource audi;
    private Collider2D col;
    private Animator ani;
    private int a = 0;
    private bool check = true;
    private void Start()
    {
        ani = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        audi = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (gameObject.GetComponent<GMADB>())
            {
                gameObject.AddComponent<GMADB>().enabled = false;
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            ani.SetBool("Break", true);
            if (check)
            {
                audi.Play();
                check = false;
            }
            if ( a == 0)
            {
                QuestManager.instance.sign++;
                a++;
            }
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            col.isTrigger = false;
        }
    }


}
