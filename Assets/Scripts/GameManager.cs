using UnityEngine;
using UnityEngine.Events;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance is null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public readonly UnityEvent OnGameOver = new();
    public readonly UnityEvent OnGameWon = new();
    private GameManager()
    {
        
    }

    public void GameOver()
    {
        OnGameOver.Invoke();
    }

    public void GameWon()
    {
        OnGameWon.Invoke();
    }
}
