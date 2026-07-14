using System.Collections;
using UnityEngine;

public class Owner : MonoBehaviour
{
    private Animator ani;
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject oiiaiSound;
    [SerializeField] private GameObject realOiiaiSound;
    [SerializeField] private GameObject bgm;
    private Animator catAni;
    private void Start()
    {
        ani = GetComponent<Animator>();
        catAni = cat.GetComponent<Animator>();
        Load.instance.RealNextChapter();
        StartCoroutine(Sad());
    }

    IEnumerator Sad()
    {
        yield return new WaitForSeconds(2);
        ani.SetBool("Sad", true);
    }

    public void SadEnding()
    {
        ani.SetBool("Sad", false);
        StartCoroutine(Happy());
    }
    IEnumerator Happy()
    {
        yield return new WaitForSeconds(1.5f);
        bgm.GetComponent<AudioSource>().enabled = false;
        catAni.SetBool("Oiai", true);
        yield return new WaitForSeconds(0.4f);
        oiiaiSound.SetActive(true);
        yield return new WaitForSeconds(1);
        catAni.SetBool("Oiai", false);
        yield return new WaitForSeconds(2);
        oiiaiSound.SetActive(false);
        realOiiaiSound.SetActive(true);
        Ending.instance.endStart = true;
    }
}
