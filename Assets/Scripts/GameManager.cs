using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static int nextScene = 1;

    public readonly UnityEvent OnGameOver = new();

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

    public static void Load()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}
