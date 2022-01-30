using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonMenu : MonoBehaviour
{
    private Canvas canvas;
    
    void Start()
    {
        canvas = GetComponent<Canvas>();
        GameManager.Instance.OnGameWon.AddListener(GameWonHandler);
    }
    
    void Update()
    {
        if (canvas.enabled && Input.GetKey(KeyCode.Space))
        {
            canvas.enabled = false;
            GameManager.Instance.GoToMainMenu();
        }
    }
    
    private void GameWonHandler()
    {
        canvas.enabled = true;
    }
}
