using UnityEngine;

public class Hwabon : MonoBehaviour
{
    [SerializeField] private GameObject catCamera;
    [SerializeField] private GameObject hwabonCamera;
    private bool check = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat") && check)
        {
            catCamera.SetActive(false);
            hwabonCamera.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Floor") && check)
        {
            catCamera.SetActive(true);
            hwabonCamera.SetActive(false);
            check = false;
        }
    }
}
