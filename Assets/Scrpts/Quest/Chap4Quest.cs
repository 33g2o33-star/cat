using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Chap4Quest : MonoBehaviour
{
    [SerializeField] private GameObject[] questList;
    [SerializeField] private GameObject bag;
    [SerializeField] private GameObject cat;
    public int questStack = 0;
    public static Chap4Quest instance;
    public bool[] questCheck = new bool[11];
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < questCheck.Length; i++)
        {
            questCheck[i] = false;
        }
    }
    private void Update()
    {
        if (questCheck[0])
        {
            QuestManager.instance.QuestUI.Clear(0, questList[0].transform.position);
            questStack++;
            QuestManager.instance.PictureUI.Quest(5);
            questCheck[0] = false;
        }
        if (questCheck[1] && questCheck[2] && questCheck[3])
        {
            QuestManager.instance.QuestUI.Clear(1, questList[1].transform.position);
            questStack++;
            questCheck[1] = false;
            questCheck[2] = false;
            questCheck[3] = false;
        }
        if (questCheck[4])
        {
            QuestManager.instance.QuestUI.Clear(2, questList[2].transform.position);
            questStack++;
            questCheck[4] = false;
        }
        if (questCheck[5])
        {
            QuestManager.instance.QuestUI.Clear(3, questList[3].transform.position);
            questStack++;
            questCheck[5] = false;
        }
        if (questCheck[6] && questCheck[7] && questCheck[8] && questCheck[9])
        {
            QuestManager.instance.QuestUI.Clear(4, questList[4].transform.position);
            questStack++;
            questCheck[6] = false;
            questCheck[7] = false;
            questCheck[8] = false;
            questCheck[9] = false;
            QuestManager.instance.PictureUI.Quest(6);
        }
        if (questStack >= 5)
        {
            questList[5].SetActive(true);
            bag.SetActive(true);
            if (questCheck[10])
            {
                cat.SetActive(false);
                QuestManager.instance.QuestUI.Clear(5, questList[5].transform.position);
                QuestManager.instance.PictureUI.Quest(7);
                NextQuest();
                questCheck[10] = false;
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
            yield return new WaitForSeconds(0.2f);
            questList[i].SetActive(false);
            QuestManager.instance.QuestUI.stamp[i].SetActive(false);
        }
        Load.instance.NextChapter();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Ending");
    }
}
