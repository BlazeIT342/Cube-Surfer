using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    public GameEvent onGameStart;
    public GameEvent onGameEnd;
    public GameEvent onAddNewCube;
    public GameEvent onCollisionWall;

    private bool isGameRunning;

    [System.Serializable]
    public class GameEvent : UnityEvent<bool> { }


    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        if (!isGameRunning)
        {
            isGameRunning = true;
            onGameStart?.Invoke(true);
        }
    }

    public void EndGame()
    {
        if (isGameRunning)
        {
            isGameRunning = false;
            onGameEnd?.Invoke(false);
        }
    }

    public void AddNewCube()
    {
        if (isGameRunning)
        {
            onAddNewCube?.Invoke(true);
        }
    }

    public void CollisionWall()
    {
        if (isGameRunning)
        {
            onCollisionWall?.Invoke(true);
        }
    }
}