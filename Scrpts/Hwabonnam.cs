using UnityEngine;

public class Hwabonnam : MonoBehaviour
{
    [SerializeField] private GameObject wet;
    [SerializeField] private GameObject run;
    private Vector3 target;
    public static Hwabonnam instance;
    public bool kong = false;
    public bool wakeUp = false;
    private Rigidbody2D rigi;
    private Vector2 dir;
    private Collider2D col;
    public Animator anim;
    private bool who = true;
    private float speed = 3f;
    private void Awake()
    {
        instance = this;
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Falling") && who)
        {             
            col.isTrigger = true;
            who = false; 
            anim.SetBool("Aya", true);
            Chap1Quest.instance.hwabon = true;
        }
    }
    private void Update()
    {      
        anim.SetFloat("Dir", dir.magnitude);
        if (dir.x > 0)
        {
            transform.localScale = new Vector3(-10, transform.localScale.y, transform.localScale.z);
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector3(10, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }
    private void FixedUpdate()
    {
        if (kong)
        {
            target = new Vector2(wet.transform.position.x - 1, wet.transform.position.y);
            dir = target - transform.position;
        }
        if (wakeUp)
        {
            target = new Vector2(run.transform.position.x + 2, run.transform.position.y);
            dir = target - transform.position;
            if (transform.position.x >= run.transform.position.x)
            {
                gameObject.SetActive(false);
            }
        }
        dir.Normalize();
        rigi.linearVelocity = dir * speed;
    }
    public void Ayaend()
    {
        anim.SetBool("Aya", false);
    }
    public void KongEnd()
    {
        gameObject.GetComponent<QuestClear>().cuCheck = true;
        anim.SetBool("Kong", false);
        dir = transform.position;
    }

}
