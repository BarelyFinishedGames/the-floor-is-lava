using System;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float rowForce = 50.0f;
    public float dragForce = 1.50f;
    public float maxSpeed = 100f;

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
        float angle = transform.localEulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle;
        Debug.Log(angle);
        if (handleInput == false)
        {
            return;
        }

        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

        float currentRotation = transform.localRotation.y;
        Vector3 pushback = Vector3.zero;
        Vector3 movement2 = Vector3.zero;

        if (angle > 45f)
        {
            pushback += Vector3.down * rowForce;
            movement2 += -transform.right * rowForce;
            rigidbody.AddTorque(pushback);
            rigidbody.AddForce(movement2);
        }

        if (angle < -45f)
        {
            pushback += Vector3.up * rowForce;
            movement2 += transform.right * rowForce;
            rigidbody.AddTorque(pushback);
            rigidbody.AddForce(movement2);
        }

        Vector3 torque = Vector3.zero;
        Vector3 movement = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.A))
        {
            torque += Vector3.up * rowForce;
            movement += transform.forward * rowForce;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            torque += -Vector3.up * rowForce;
            movement += transform.forward * rowForce;
        }

        rigidbody.AddTorque(torque);
        rigidbody.AddForce(movement);

        rigidbody.drag = dragForce;
    }
}