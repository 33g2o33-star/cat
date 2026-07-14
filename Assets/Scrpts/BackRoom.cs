using System.Collections;
using UnityEngine;

public class BackRoom : MonoBehaviour
{
    void Start()
    {
        Load.instance.RealNextChapter();
        StartCoroutine(Backroom());
    }

    IEnumerator Backroom()
    {
        yield return new WaitForSeconds(5f);
        Ending.instance.endStart = true;
    }

}
