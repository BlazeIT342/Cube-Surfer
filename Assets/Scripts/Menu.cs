using TZ.Control;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject endMenu;
    bool firstTouch = false;

    private void Awake()
    {
        startMenu.SetActive(true);
        endMenu.SetActive(false);
        Time.timeScale = 1.5f;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !firstTouch)
        {
            firstTouch = true;
            startMenu.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SetIsStopped(false);
        }
    }

    public void GameOver()
    {
        endMenu.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}