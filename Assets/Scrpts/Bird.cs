using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Rigidbody2D rigi;
    private Animator anim;
    private SpriteRenderer spriter;
    private Vector2 dir;
    private Vector3 realTarget;
    private float speed = 4f;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        QuestManager.instance.bird = true;
    }
    private void FixedUpdate()
    {
        if (transform.position != target.transform.position)
        {
            realTarget = new Vector3(target.transform.position.x -5, target.transform.position.y);
            dir = realTarget - transform.position;
            dir.Normalize();           
        }
        rigi.linearVelocity = dir * speed;
        anim.SetFloat("Dir", dir.magnitude);
        if (dir.x != 0)
        {
            spriter.flipX = dir.x > 0;
        }

        if (transform.position.x < realTarget.x)
        {
            gameObject.SetActive(false);
        }
    }
}
