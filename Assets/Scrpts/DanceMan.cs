using UnityEngine;

public class DanceMan : MonoBehaviour
{
    [SerializeField] private GameObject dancingMan;
    [SerializeField] private GameObject sound;
    private void OnEnable()
    {
        dancingMan.GetComponent<Animator>().SetBool("Use", true);
        gameObject.GetComponent<UseItem>().enabled = false;
        gameObject.GetComponent<QuestClear>().cuCheck = true;
        sound.SetActive(false);

    }
    private void OnDisable()
    {
        if (dancingMan.GetComponent<Animator>() != null)
        {
            dancingMan.GetComponent<Animator>().SetBool("Use", false);
        }
        else
        {
            return;
        }
        gameObject.GetComponent<UseItem>().enabled = false;
        sound.SetActive(true);
    }
}
