using UnityEngine;

public class UseItem : MonoBehaviour
{
    private Animator ani;
    private bool dance = true;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        if (gameObject.GetComponent<BreakItem>())
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
            if (gameObject.GetComponent<GMADB>())
            {
                gameObject.GetComponent<GMADB>().enabled = true;
            }
            else if (gameObject.GetComponent<Orange>())
            {
                gameObject.GetComponent<Orange>().enabled = true;
            }
            else
            {
                return;
            }
        }
        else if (gameObject.GetComponent<DanceMan>())
        {
            gameObject.GetComponent<DanceMan>().enabled = dance;
            dance = !dance;
            return;
        }

        ani.SetBool("Use", true);
        if (gameObject.GetComponent<Catbaking>())
        {
            gameObject.GetComponent<Catbaking>().enabled = true;
        }
        if (gameObject.GetComponentInChildren<Bird>())
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            gameObject.GetComponentInChildren<Bird>().enabled = true;
        }
        if (gameObject.GetComponent<Open>())
        {
            gameObject.GetComponent<Open>().enabled = true;
        }
    }
}
