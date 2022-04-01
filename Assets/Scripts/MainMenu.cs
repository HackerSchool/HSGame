using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame1()
    {
        SceneManager.LoadScene("FloppyDisk");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
