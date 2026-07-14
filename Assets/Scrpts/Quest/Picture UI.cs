using UnityEngine;


public class PictureUI : MonoBehaviour
{
    [SerializeField] private GameObject[] picturesPrefabs;
    private int save;
    private int savee;
    private int saveee;
    private int saveeee;
    private int saveeeee;
    private int saveeeeee;
    private int saveeeeeee;
    private int saveeeeeeee;
    private void Start()
    {
        save = PlayerPrefs.GetInt("Save0");
        savee = PlayerPrefs.GetInt("Save1");
        saveee = PlayerPrefs.GetInt("Save2");
        saveeee = PlayerPrefs.GetInt("Save3");
        saveeeee = PlayerPrefs.GetInt("Save4");
        saveeeeee = PlayerPrefs.GetInt("Save5");
        saveeeeeee = PlayerPrefs.GetInt("Save6");
        saveeeeeeee = PlayerPrefs.GetInt("Save7");
        if (save == 1)
        {
            Quest(0);
        }
        if (savee == 1)
        {
            Quest(1);
        }
        if (saveee == 1)
        {
            Quest(2);
        }
        if (saveeee == 1)
        {
            Quest(3);
        }
        if (saveeeee == 1)
        {
            Quest(4);
        }
        if (saveeeeee == 1)
        {
            Quest(5);
        }
        if (saveeeeeee == 1)
        {
            Quest(6);
        }
        if (saveeeeeeee == 1)
        {
            Quest(7);
        }
    }
    public void Quest(int q)
    {
        picturesPrefabs[q].SetActive(true);
        switch (q)
        {
            case 0:
                PlayerPrefs.SetInt("Save0", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("Save1", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("Save2", 1);
                break;
            case 3:
                PlayerPrefs.SetInt("Save3", 1);
                break;
            case 4:
                PlayerPrefs.SetInt("Save4", 1);
                break;
            case 5:
                PlayerPrefs.SetInt("Save5", 1);
                break;
            case 6:
                PlayerPrefs.SetInt("Save6", 1);
                break;
            case 7:
                PlayerPrefs.SetInt("Save7", 1);
                break;
        }
    }
}
