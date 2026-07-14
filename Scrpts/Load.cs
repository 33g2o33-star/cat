using System.Collections;
using UnityEngine;

public class Load : MonoBehaviour
{
    private Rigidbody2D ri;
    [SerializeField] private GameObject catMove;
    [SerializeField] private float loadSpeed = 8f;
    [SerializeField] private GameObject title;
    private Vector2 curtp;
    public static Load instance;

    private void Awake()
    {
        ri = GetComponent<Rigidbody2D>();
        instance = this;
    }

    private void FixedUpdate()
    {
        curtp = transform.position;
        curtp.y = Mathf.Clamp(transform.position.y, 540 + 40, 1080 + 540);
        transform.position = curtp;
    }
    public void Starting()
    {
        catMove.GetComponent<CatMove>().enabled = true;
    }
    public void Loading()
    {
        StartCoroutine(wait());
        ri.linearVelocity = new Vector2(ri.linearVelocityX, -loadSpeed);
    }


    public void AnothorLoading()
    {
        StartCoroutine(anothorwait());
        ri.linearVelocity = new Vector2(ri.linearVelocityX, -loadSpeed);
    }
    public void GoTitile()
    {
        StartCoroutine(GoingTitle());
        ri.linearVelocity = new Vector2(ri.linearVelocityX, -loadSpeed);
    }

    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(1f);
        title.SetActive(false);
        ri.linearVelocity = new Vector2(ri.linearVelocityX, loadSpeed);      
        yield return new WaitForSeconds(1f);
    }
    IEnumerator anothorwait()
    {
        
        yield return new WaitForSeconds(1f);  
        title.SetActive(true);
        Title.instance.cattitle();
        ri.linearVelocity = new Vector2(ri.linearVelocityX, loadSpeed);  
        yield return new WaitForSeconds(1f);       
    }
    IEnumerator GoingTitle()
    {
        yield return new WaitForSeconds(1f);
        title.SetActive(true);
        ri.linearVelocity = new Vector2(ri.linearVelocityX, loadSpeed);
        yield return new WaitForSeconds(1f);
    }
    
    public void NextChapter()
    {
        ri.linearVelocity = new Vector2(ri.linearVelocityX, -loadSpeed);
        catMove.GetComponent<CatMove>().enabled = false;
    }
    public void RealNextChapter()
    {
        ri.linearVelocity = new Vector2(ri.linearVelocityX, loadSpeed);
        if(catMove.GetComponent<CatMove>() != null)
        {
            catMove.GetComponent<CatMove>().enabled = true;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
