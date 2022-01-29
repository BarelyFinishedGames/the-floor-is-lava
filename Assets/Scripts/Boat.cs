using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float rowForce = 50.0f;

    private bool handleInput = true;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        GameManager.Instance.OnGameOver.AddListener(GameOverHandler);
    }
    
    private void GameOverHandler()
    {
        handleInput = false;
    }

    void Update()
    {
        if (handleInput == false)
        {
            return;
        }

        Vector3 torque = Vector3.zero;
        Vector3 movement = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.A))
        {
            torque += Vector3.up * rowForce;
            movement += transform.forward * rowForce;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            torque += -Vector3.up * rowForce;
            movement += transform.forward * rowForce;
        }
        
        rigidbody.AddTorque(torque);
        rigidbody.AddForce(movement);
    }

}
