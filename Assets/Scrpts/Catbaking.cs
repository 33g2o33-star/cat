using UnityEngine;

public class Catbaking : MonoBehaviour
{
    private Animator anim;
    private AudioSource audi;
    private void OnEnable()
    {
        anim = QuestManager.instance.Cat.GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        anim.SetBool("baking", true);
        audi.Play();
    }
}
