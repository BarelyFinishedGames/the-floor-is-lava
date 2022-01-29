using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public float xAxis;
    public float yAxis;
    public float zAxis;

    void Update()
    {
        transform.Rotate(new Vector3(xAxis * rotationSpeed, yAxis * rotationSpeed, zAxis * rotationSpeed) * Time.deltaTime) ;
    }
}