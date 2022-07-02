using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameState {
    START,
    RUNNING,
    PAUSED,
    END
}
public class GameController : MonoBehaviour
{
    [SerializeField] IntVariable score;  
    [SerializeField] GameState state;
    [SerializeField] UnityEvent<int> onScoreUpdate;

    public GameObject gameStartMenu;
    public GameObject gameOverMenu;

    private int level;

    // Start is called before the first frame update
    void Start()
    {
        score.value = 0;
        level = 0;
        ChangeGameState(GameState.START);  
    }

    public void IncreaseScore(int quantity)
    {
        score.value += quantity;
        onScoreUpdate.Invoke(score.value);
    }

    void OnStart(InputValue value)
    {
        ChangeGameState(GameState.RUNNING);
    }

    public void GameOver()
    {
        ChangeGameState(GameState.END);
    }


    public void ChangeGameState(GameState newState)
    {
        switch(newState)
        {
            case GameState.START:
                Time.timeScale = 0;
                gameStartMenu.SetActive(true);
                state = newState;
                break;
            case GameState.RUNNING:
                TransitionToRunning();
                break;
            case GameState.PAUSED:
                Time.timeScale = 0;
                state = newState;
                break;
            case GameState.END:
                Time.timeScale = 0;
                gameOverMenu.SetActive(true);
                gameObject.GetComponent<Level1>().StopLevel();
                state = newState;
                break;
            default:
                break;
        }
    }

    public void TransitionToRunning()
    {
        Time.timeScale = 1;
        switch(state)
        {
            case GameState.START:
                gameStartMenu.SetActive(false);
                IncreaseLevel();
                state = GameState.RUNNING;
                break;
            case GameState.PAUSED:
                break;
            case GameState.END:
                Time.timeScale = 0;
                break;
            default:
                break;
        }
    }

    IEnumerator LevelTransition()
    {
        yield return new WaitForSeconds(3.0f);
        switch(level)
        {
            case 1:
                gameObject.GetComponent<Level1>().StartLevel();
                break;
            default:
                break;
        }
    }

    private void IncreaseLevel()
    {
        level += 1;
        StartCoroutine(LevelTransition());
    }

    public void ResetGame() {
        SceneManager.LoadScene("FloppyDisk");
    }

    public void QuitGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
