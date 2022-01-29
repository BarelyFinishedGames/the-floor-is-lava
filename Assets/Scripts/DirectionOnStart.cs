using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionOnStart : MonoBehaviour
{
    public Transform target;
    public float angle;
    public bool turnAround;

    void Start()
    {
        //transform.LookAt(target); das geht nit :(
        transform.Rotate(angle, 0, 0);

        if (turnAround)
        {
            transform.Rotate(angle, 180, 0);
        }
    }
}