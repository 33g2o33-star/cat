using UnityEngine;

public class Chalkac : MonoBehaviour
{
    [SerializeField] private GameObject girl;
    [SerializeField] private GameObject boy;
    private AudioSource chalkac;
    private bool chch = true;
    private Animator ani;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat") && chch)
        {
            ani = girl.GetComponent<Animator>();
            chalkac = GetComponent<AudioSource>();
            ani.SetBool("IsChalkac", true);
            chalkac.Play();
            boy.GetComponent<Animator>().SetBool("IsChalkac", true);
            chch = false;
        }
        
    }
    
    public void No()
    {
        gameObject.GetComponent<QuestClear>().cuCheck = true;
        ani.SetBool("IsChalkac", false);
        boy.GetComponent<Animator>().SetBool("IsChalkac", false);
    }

}
