using UnityEngine;

public class Sign : MonoBehaviour
{ 
    [SerializeField] private GameObject[] dish;
    private void Update()
    {
        if (gameObject.GetComponent<UseItem>().enabled)
        {
            for (int i = 0; i < dish.Length; i++) 
            {
                dish[i].SetActive(true);
            }
        }
    }
}
