using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private static int nextScene = 1;

    public readonly UnityEvent OnGameOver = new();
    public readonly UnityEvent OnGameWon = new();
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        SceneManager.LoadScene(nextScene);
    }

    public void GameOver()
    {
        OnGameOver.Invoke();
    }

    public void GameWon()
    {
        OnGameWon.Invoke();
    }
    
    public static void Load()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}