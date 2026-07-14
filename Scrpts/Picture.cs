using UnityEngine;

public class Picture : MonoBehaviour
{
    public GameObject[] pictures;
    
    public void Pic(int num)
    {
        pictures[num].SetActive(true);
        gameObject.SetActive(true);
    }
    public void Gone(int num)
    {
        pictures[num].SetActive(false);
        gameObject.SetActive(false);
    }
}
