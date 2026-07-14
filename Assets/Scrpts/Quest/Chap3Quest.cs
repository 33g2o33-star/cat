using UnityEngine;
using System.Collections;

public class Chap3Quest : MonoBehaviour
{
    [SerializeField] private GameObject[] questList;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject chapF;
    public int questStack = 0;
    public static Chap3Quest instance;
    public bool[] questCheck = new bool[4];
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < questCheck.Length; i++)
        {
            questCheck[i] = false;
        }
    }
    private void Start()
    {
        Load.instance.RealNextChapter();
    }
    private void Update()
    {
        if (questCheck[0])
        {
            QuestManager.instance.QuestUI.Clear(0, questList[0].transform.position);
            questStack++;
            QuestManager.instance.PictureUI.Quest(3);
            questCheck[0] = false;
        }
        if (questCheck[1])
        {
            QuestManager.instance.QuestUI.Clear(1, questList[1].transform.position);
            questStack++;
            questCheck[1] = false;
        }
        if (questCheck[2])
        {
            QuestManager.instance.QuestUI.Clear(2, questList[2].transform.position);
            questStack++;
            questCheck[2] = false;
            QuestManager.instance.PictureUI.Quest(4);
        }
        if (questStack >= 3)
        {
            wall.GetComponent<Collider2D>().isTrigger = true;
            questList[3].SetActive(true);
            if (questCheck[3])
            {
                QuestManager.instance.QuestUI.Clear(3, questList[3].transform.position);
                questCheck[3] = false;
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
        chapF.SetActive(true);
        gameObject.SetActive(false);
    }

}
