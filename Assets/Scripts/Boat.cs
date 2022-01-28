using Unity.VisualScripting;
using UnityEngine;

public class Boat : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("left");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("right");
        }
    }

}
