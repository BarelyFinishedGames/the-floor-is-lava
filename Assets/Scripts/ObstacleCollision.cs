using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boat"))
        {
            Debug.Log(collision.gameObject);
            AudioManager.StartSound("stoneSound");
            GameManager.Instance.GameOver();
        }
    }
}
