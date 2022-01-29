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

        private void GameOverHandler()
        {
            canvas.enabled = true;
        }
    }
}
