using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float rowForce = 50.0f;
    public float dragForce = 1.50f;
    public float maxSpeed = 100f;

    private bool handleInput = true;

    public Animator paddleLeftAnim;
    public Animator paddleRightAnim;

    public float maxRowAnimSpeed = 3.0f;

    private float lastRowRight;
    private float lastRowLeft;
    private static readonly int RowRightAnim = Animator.StringToHash("RowRight");
    private static readonly int RowLeftAnim = Animator.StringToHash("RowLeft");

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

        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

        Vector3 torque = Vector3.zero;
        Vector3 movement = Vector3.zero;

        float now = Time.fixedTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            torque += Vector3.up * rowForce;
            movement += transform.forward * rowForce;
            
            float delta = now - lastRowLeft;
            float speed = 1 + 1 / delta;
            paddleLeftAnim.speed = Mathf.Clamp(speed, 1, maxRowAnimSpeed);
            paddleLeftAnim.SetTrigger(RowLeftAnim);

            lastRowRight = now;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            torque += -Vector3.up * rowForce;
            movement += transform.forward * rowForce;


            float delta = now - lastRowRight;
            float speed = 1 + 1 / delta;
            paddleRightAnim.speed = Mathf.Clamp(speed, 1, maxRowAnimSpeed);
            paddleRightAnim.SetTrigger(RowRightAnim);

            lastRowRight = now;
        }

        rigidbody.AddTorque(torque);
        rigidbody.AddForce(movement);

        rigidbody.drag = dragForce;
    }
}