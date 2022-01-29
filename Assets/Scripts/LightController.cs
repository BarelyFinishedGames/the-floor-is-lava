using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject spotlight;
    float startTime;
    float duration = 5.0f;

    
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        if (Vector3.Angle(spotlight.transform.forward, transform.position - spotlight.transform.position) < angle)
        {
            GetComponent<Light>().intensity = 0.2f;
        }
        else
        {
            GetComponent<Light>().intensity = 0;
        }
    }
}
