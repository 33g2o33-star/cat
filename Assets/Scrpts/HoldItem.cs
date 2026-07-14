using UnityEngine;

public class HoldItem : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer spriter;
    [SerializeField] private GameObject catMouse;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    public void OnEnable()
    {
        col.isTrigger = true;
        
    }
    private void Update()
    {
        transform.position = catMouse.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, 90);
        if (QuestManager.instance.Cat.dir.x != 0)
        {
            spriter.flipY = QuestManager.instance.Cat.dir.x > 0;
        }
    }

    public void OnDisable()
    {
        col.isTrigger = false;
    }




}
