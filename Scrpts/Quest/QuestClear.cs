using UnityEngine;

public class QuestClear : MonoBehaviour
{
    [SerializeField] private int chapNumber;
    [SerializeField] private int quNumber;
    private bool cheak = true;
    public static QuestClear Instance;
    public bool cuCheck = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (gameObject.GetComponent<UseItem>() != null && gameObject.GetComponent<UseItem>().enabled && cheak)
        {
            QuestManager.instance.GoQuest(chapNumber, quNumber);
            cheak = false;
        }
        else if (cheak && cuCheck)
        {
            QuestManager.instance.GoQuest(chapNumber, quNumber);
            cheak = false;
        }
}
}
