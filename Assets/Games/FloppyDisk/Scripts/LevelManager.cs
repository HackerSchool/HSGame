using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public int score;
    public int level;
    public GameObject darkness;
    public GameObject gameStartMenu;
    public GameObject GameOverMenuPrefab;
    public GameObject Boss;
    public UnityEvent activateObstacleInvisibilty;
    public UnityEvent deactivateObstacleInvisibilty;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int score = int.Parse(GameObject.Find("Score").GetComponent<ScoreManager>().GetScore());
        if(level == 1 && score == 0) {
            gameObject.GetComponent<Level1>().StartLevel();
        }
    }


    /*******************************************************************/
    /*                       OTHER FUNCTIONS                           */
    /*******************************************************************/
    void OnStart(InputValue value)
    {
        if(gameStartMenu != null) {
            GameObject.Destroy(gameStartMenu);
            gameStartMenu = null;
            Time.timeScale = 1;
        }
    }

    void OnDarkness() {
        GameObject.Instantiate(darkness);
        darkness.GetComponent<Darkness>().SetDuration(5.0f);
    }

    void DisappearingObstacles() {
        activateObstacleInvisibilty.Invoke();
    }

    void normalObstacles() {
        deactivateObstacleInvisibilty.Invoke();
    }

    public void GameOver()
    {
        GameOverMenuPrefab.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetGame() {
        Time.timeScale = 1;
        GameObject.Find("Score").GetComponent<ScoreManager>().ResetStore();
        SceneManager.LoadScene("FloppyDisk");
    }

    public void QuitGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
