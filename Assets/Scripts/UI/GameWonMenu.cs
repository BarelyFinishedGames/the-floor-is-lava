using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonMenu : MonoBehaviour
{
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        GameManager.Instance.OnGameWon.AddListener(GameWonHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void GameWonHandler()
    {
        canvas.enabled = true;
    }
}
