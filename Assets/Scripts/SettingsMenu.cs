using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float gameEffectsAudio = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeGameMasterAudio(float value)
    {
        audioMixer.SetFloat("MasterAudio", value);
    }

    public void ChangeGameEffectsAudio(float value)
    {
        gameEffectsAudio = value;
    }

    public void ChangeScreenSize(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
}
