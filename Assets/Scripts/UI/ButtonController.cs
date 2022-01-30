using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonController : MonoBehaviour
    {
        private void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(PlayClickSound);
        }

        public void PlayGame()
        {
            GameManager.Instance.StartGame();
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public void ResumeGame()
        {
            GameManager.Instance.TogglePause();
        }

        private void PlayClickSound()
        {
            AudioManager.StartSound("buttonSound");
        }
    }
}
