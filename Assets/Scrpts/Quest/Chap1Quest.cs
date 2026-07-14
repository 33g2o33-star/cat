using System.Collections;
using UnityEngine;

public class Chap1Quest : MonoBehaviour
{
    [SerializeField] private GameObject[] questList;
    [SerializeField] private GameObject chapTwo;
    public int questStack = 0;
    private bool[] arr = new bool[5];
    public static Chap1Quest instance;
    public bool market = false;
    public bool hwabon = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Load.instance.RealNextChapter();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = true;
        }
    }
    void Update()
    {
        
        if (QuestManager.instance.Bake.GetComponent<Catbaking>().enabled && arr[0])
        {
            QuestManager.instance.QuestUI.Clear(0, questList[0].transform.position);
            QuestManager.instance.PictureUI.Quest(0);
            arr[0] = false;
            questStack++;
        }
        if  (QuestManager.instance.trash == true && arr[1])
        {
            QuestManager.instance.QuestUI.Clear(1, questList[1].transform.position);
            arr[1] = false;
            questStack++;
        }
        if (QuestManager.instance.bird == true && arr[2])
        {
            QuestManager.instance.QuestUI.Clear(2, questList[2].transform.position);
            arr[2] = false;
            questStack++;
        }
        if (QuestManager.instance.sign >= 3 && arr[3])
        {
            QuestManager.instance.QuestUI.Clear(3, questList[3].transform.position);
            arr[3] = false;
            questStack++;
        }
        if (questStack >= 4)
        {
            arr[4] = false;
            questList[4].SetActive(true);
            if (hwabon && market)
            {
                questStack++;
                QuestManager.instance.PictureUI.Quest(1);
                QuestManager.instance.QuestUI.Clear(4, questList[4].transform.position);
                NextQuest();
            }
        }
    }

    void NextQuest()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        for (int i = questList.Length - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.3f);
            questList[i].SetActive(false);
            QuestManager.instance.QuestUI.stamp[i].SetActive(false);
        }
        chapTwo.SetActive(true);
        gameObject.SetActive(false);
    }


}
