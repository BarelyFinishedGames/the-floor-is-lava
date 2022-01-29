using UnityEngine;

public class FollowerCam : MonoBehaviour
{
    public Transform target;
    private Quaternion initialRotation;
    private Vector3 targetOffset;
    void Start()
    {
        initialRotation = transform.rotation;
        targetOffset = target.transform.position - transform.position;
    }

    void Update()
    {
        transform.rotation = initialRotation;
        transform.position = target.position - targetOffset;
    }
}
