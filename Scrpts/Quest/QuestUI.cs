using UnityEngine;

public class QuestUI : MonoBehaviour
{   
    [SerializeField] public GameObject[] stamp;
    [SerializeField] private  GameObject stampPrefabs;

    private void Start()
    {
        for (int i = 0; i < stamp.Length; i++)
        {
            stamp[i] = Instantiate(stampPrefabs, transform);
            stamp[i].SetActive(false);
        }
    }

    public void Clear(int i, Vector2 tran)
    {
        stamp[i].SetActive(true);
        stamp[i].transform.position = tran;
    }
}
