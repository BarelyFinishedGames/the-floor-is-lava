using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTo : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        transform.position = target.position;
    }
}
