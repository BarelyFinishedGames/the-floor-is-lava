using UnityEditor;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Canvas))]
    public class GameOverMenu : MonoBehaviour
    {
        private Canvas canvas;
        void Start()
        {
            canvas = GetComponent<Canvas>();
            GameManager.Instance.OnGameOver.AddListener(GameOverHandler);
        }
        
        void Update()
        {
            if (canvas.enabled && Input.GetKey(KeyCode.Return))
            {
                GameManager.Instance.GoToMainMenu();
            }
        }

        private void GameOverHandler()
        {
            canvas.enabled = true;
        }
    }
}
