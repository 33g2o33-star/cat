using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject orangeBox;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            gameObject.SetActive(false);
            if (orange.GetComponent<Orange>() != null)
            {
                orange.GetComponent<Orange>().enabled = true;
            }
            else
            {
            }
            if (orangeBox.GetComponent<Orange>() != null)
            {
                orangeBox.GetComponent<Orange>().enabled = true;
            }
            else
            {
            }
        }
    }
}
