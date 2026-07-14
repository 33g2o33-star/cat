using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public static Ending instance;
    private Rigidbody2D rigi;
    public bool endStart = false;
    private void Awake()
    {
        instance = this;
        rigi = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (endStart)
        {
            rigi.linearVelocity = Vector3.up * 400;
            if (transform.position.y >= 1275)
            {
                endStart = false;
                rigi.linearVelocity = Vector3.zero;
                StartCoroutine(End());
            }
        }
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        Load.instance.GoTitile();
        SceneManager.LoadScene("0Tutorial");
    }
}
