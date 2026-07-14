using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chap2Quest : MonoBehaviour
{
    [SerializeField] private GameObject[] questList;
    public int questStack = 0;
    public static Chap2Quest instance;
    public bool[] questCheck = new bool[6];
    public bool nextchap = false;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < questCheck.Length; i++)
        {
            questCheck[i] = false;
        }
    }
    void Update()
    {
        if (questCheck[0] &&  questCheck[1])
        {
            QuestManager.instance.QuestUI.Clear(0, questList[0].transform.position);
            questStack++;
            questCheck[0] = false;
        }
        if (questCheck[2])
        {
            QuestManager.instance.QuestUI.Clear(1, questList[1].transform.position);
            questStack++;
            QuestManager.instance.PictureUI.Quest(2);
            questCheck[2] = false;
        }
        if (questCheck[3])
        {
            QuestManager.instance.QuestUI.Clear(2, questList[2].transform.position);
            questStack++;
            questCheck[3] = false;
        }
        if (questCheck[4])
        {
            QuestManager.instance.QuestUI.Clear(3, questList[3].transform.position);
            questStack++;
            questCheck[4] = false;
        }
        if (questStack >= 4)
        {
            questList[4].SetActive(true);
            nextchap = true;
            if (questCheck[5])
            {
                QuestManager.instance.QuestUI.Clear(4, questList[4].transform.position);
                NextQuest();
                questCheck[5] = false;
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
        SceneManager.LoadScene("3Chapter");
    }


}
