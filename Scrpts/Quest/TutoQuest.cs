using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoQuest : MonoBehaviour
{
    [SerializeField] private GameObject[] questList;
    public int queststack = 0;
    private bool[] arr = new bool[3];

    private void Start()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = true;
        }
    }
    private void Update()
    {
        if ( QuestManager.instance.Cat.dir.x != 0 && arr[0])
        {
            QuestManager.instance.QuestUI.Clear(0, questList[0].transform.position);
            arr[0] = false;
            queststack++;
        }
        if ( QuestManager.instance.Cat.canjum == false && arr[1])
        {
            QuestManager.instance.QuestUI.Clear(1, questList[1].transform.position);
            arr[1] = false;
            queststack++;
        }
        if (QuestManager.instance.CatQ.isHolding && arr[2])
        {
            QuestManager.instance.QuestUI.Clear(2, questList[2].transform.position);
            queststack++;
            arr[2] = false;
        }
        if (queststack >= questList.Length )
        {
            StartCoroutine(Next());

        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(1.5f);
        Load.instance.NextChapter();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("1Chapter");
    }
}
