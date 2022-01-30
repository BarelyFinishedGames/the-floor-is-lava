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
            gameObject.GetComponentInChildren<Button>().onClick.AddListener(PlayClickSound);
        }

        public void PlayGame()
        {
            //TODO: Configure build settings
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
        
        
        
        private void PlayClickSound()
        {
            Debug.Log("play sound");
            AudioManager.StartSound("buttonSound");
        }
    }
}
