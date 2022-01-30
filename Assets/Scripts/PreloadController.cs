using UnityEngine;

public class PreloadController : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.Find("GameManager") is null)
        {
            GameManager.Load();
        }
    }
}
