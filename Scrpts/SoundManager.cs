using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioMixer audioMixer;
    private string masterAudio = "Master";
    private void Awake()
    {
        instance = this;
    }
    public void SetVolume(float volume)
    {
        float setVolume = Mathf.Max(volume, 0.0001f);
        audioMixer.SetFloat(masterAudio, Mathf.Log10(setVolume) * 20);
    }

}
