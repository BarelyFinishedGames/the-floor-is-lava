using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionOnStart : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        transform.LookAt(target);
    }
}
