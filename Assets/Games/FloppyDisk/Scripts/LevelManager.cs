using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public int score;
    public GameObject darkness;
    public GameObject gameStartMenu;
    public GameObject GameOverMenuPrefab;
    public UnityEvent activateObstacleInvisibilty;
    public UnityEvent deactivateObstacleInvisibilty;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStart(InputValue value)
    {
        if(gameStartMenu != null) {
            GameObject.Destroy(gameStartMenu);
            gameStartMenu = null;
            Time.timeScale = 1;
        }
    }

    void Darkness() {
        GameObject.Instantiate(darkness);
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
        SceneManager.LoadScene("FloppyDisk");
    }

    public void QuitGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
