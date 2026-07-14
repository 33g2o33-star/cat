using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CatMove : MonoBehaviour
{
    [SerializeField] private BoxCollider2D colly;
    [SerializeField] private BoxCollider2D back;
    private bool x = true;
    private AudioSource meow;
    public Rigidbody2D rigi;
    private Animator ani;
    private Collider2D col;
    public bool canjum = true;
    private float minlimitX;
    private float maxlimitX;
    private float minlimitY;
    private float maxlimitY;
    private float offset = 1.3f;
    private Vector2 curPos;

    public Vector2 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        meow = GetComponent<AudioSource>();
    }
    private void Start()
    {
        ani.SetBool("baking", true);
        minlimitX = colly.bounds.min.x;
        maxlimitX = colly.bounds.max.x;
        minlimitY = colly.bounds.min.y;
        maxlimitY = colly.bounds.max.y;
    }

    public void StartWalking()
    {
        ani.SetBool("baking", false);
    }
    void Update()
    {
        ani.SetFloat("Dir", dir.magnitude);
        if (dir.x > 0)
        {
            transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.Q) && !QuestManager.instance.CatQ.isHolding)
        {
            QuestManager.instance.CatQ.Use();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && QuestManager.instance.CatQ.isHolding)
        {
            QuestManager.instance.CatQ.Drop();
        }
        if (Input.GetKeyDown(KeyCode.Space) && canjum) // 응 인풋 안쓸거임ㅋ
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        rigi.linearVelocity = new Vector2(dir.x * speed, rigi.linearVelocityY);
        curPos.x = Mathf.Clamp(transform.position.x , minlimitX + offset, maxlimitX - offset);
        curPos.y = Mathf.Clamp(transform.position.y, minlimitY + offset, maxlimitY - offset);
        transform.position = curPos;
    }

    public void OnMove(InputValue value)
    {
        dir = value.Get<Vector2>();

    }
    public void Jump()
    {
        if (x == true)
        {
            meow.Play();
        }
        x = !x;
        canjum = false;
        ani.SetBool("baking", false);
        ani.SetBool("Jump", true);
        rigi.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        col.isTrigger = true;
    }
    public void CucumJump()
    {
        ani.SetBool("Jump", true);
        rigi.AddForce(Vector2.up * jumpPower * 1.2f, ForceMode2D.Impulse);
        canjum = false;
    }

    public void JumpEnd()
    {
        col.isTrigger = false;
        ani.SetBool("Jump", false);
    }
    public void JumpCol()
    {
        col.isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            col.isTrigger = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        col.isTrigger = false;
        if (!collision.gameObject.CompareTag("Untagged"))
        {
            canjum = true;
        }
        if (collision.gameObject == back)
        {
            SceneManager.LoadScene("BackroomEnding");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged"))
        {
            col.isTrigger = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == back)
        {
            SceneManager.LoadScene("BackroomEnding");
        }
    }

}
