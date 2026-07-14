using UnityEngine;

public class RestScreen : MonoBehaviour
{
    public static RestScreen instance;

    private void Awake()
    {
        instance = this;
    }
    public void Appear()
    {
        gameObject.SetActive(true);
    }
    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
