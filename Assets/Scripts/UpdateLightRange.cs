using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class UpdateLightRange : MonoBehaviour
{
    public Transform target;

    private Light _light;
    private void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        _light.range = Vector3.Distance(transform.position, target.position) *2;
    }
}
