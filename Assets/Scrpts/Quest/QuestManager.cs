using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [field: SerializeField]
    public QuestUI QuestUI { get; private set; }
    [field: SerializeField]
    public CatMove Cat { get; private set; }
    [field: SerializeField]
    public PictureUI PictureUI { get; private set; }
    [field: SerializeField]
    public CatUse CatQ { get; private set; }
    [field: SerializeField]
    public Catbaking Bake { get; private set; }
    public static QuestManager instance;
    public int sign = 0;
    public bool trash = false;
    public bool bird = false;

    private void Awake()
    {
        instance = this;
    }

    public void GoQuest(int cn, int qn)
    {
        switch (cn)
        {
            case 1:
                Chap2Quest.instance.questCheck[qn] = true;
                break;
            case 2:
                Chap3Quest.instance.questCheck[qn] = true;
                break;
            case 3:
                Chap4Quest.instance.questCheck[qn] = true;
                break;

        }
    }

}
