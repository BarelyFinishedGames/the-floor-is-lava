using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float rowForce = 50.0f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
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
