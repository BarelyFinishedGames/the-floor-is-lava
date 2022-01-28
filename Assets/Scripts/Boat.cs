using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float rowForce = 50.0f;
        Vector3 torque = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.A))
        {
            torque += Vector3.up * rowForce;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            torque += -Vector3.up * rowForce;
        }
        
        rigidbody.AddTorque(torque);
    }

}
