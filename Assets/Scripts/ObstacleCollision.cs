using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boat"))
        {
            AudioManager.StartSound("stoneSound");
            GameManager.Instance.GameOver();
        }
    }
}
