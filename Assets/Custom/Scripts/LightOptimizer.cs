using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOptimizer : MonoBehaviour
{
    private Transform Cam;
    private Light ThisLight;
    void Start()
    {
        Cam = GameObject.Find("Cam").transform;
        ThisLight = GetComponent<Light>();
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, Cam.position) < 40)
        {
            ThisLight.enabled = true;
        }
        else
        {
            ThisLight.enabled = false;
        }
    }
}
