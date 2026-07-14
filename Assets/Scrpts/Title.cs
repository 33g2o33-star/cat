using UnityEngine;

public class Title : MonoBehaviour
{
    public static Title instance;

    private void Awake()
    {
        instance = this;
    }

    public void cattitle()
    {
        RestScreen.instance.Disappear();
        gameObject.SetActive(true);
    }
}
