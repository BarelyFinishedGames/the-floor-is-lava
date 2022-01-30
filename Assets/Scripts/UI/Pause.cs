using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class Pause : MonoBehaviour
    {
        public Canvas canvas;

        public List<GameObject> preventPauseScreenObjects = new ();
    
        private void Start()
        {
            GameManager.Instance.OnPauseToggled.AddListener(OnPausedChanged);
        }

        private void OnPausedChanged(bool paused)
        {
            canvas.gameObject.SetActive(paused);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
            if (!GameManager.Instance.Paused)
            {
                if (preventPauseScreenObjects.Any(obj =>
                    {
                        var component = obj.GetComponent<Canvas>();

                        return component != null && component.isActiveAndEnabled;
                    }))
                {
                    return;
                }
            }

            GameManager.Instance.TogglePause();
        }
    }
}
