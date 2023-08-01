using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject endMenu;
    bool firstTouch = false;

    private void OnEnable()
    {
        GameEventManager.instance.onGameStart.AddListener(OnGameStart);
        GameEventManager.instance.onGameEnd.AddListener(OnGameEnd);
    }

    private void OnDisable()
    {
        GameEventManager.instance.onGameStart.RemoveListener(OnGameStart);
        GameEventManager.instance.onGameEnd.RemoveListener(OnGameEnd);
    }

    private void OnGameStart(bool isGameRunning)
    {
        firstTouch = true;
        startMenu.SetActive(false);
    }

    private void OnGameEnd(bool isGameRunning)
    {
        endMenu.SetActive(true);
        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        startMenu.SetActive(true);
        endMenu.SetActive(false);
        Time.timeScale = 1.5f;
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && !firstTouch)
        {
            GameEventManager.instance.StartGame();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}