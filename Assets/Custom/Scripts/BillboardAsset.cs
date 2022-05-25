using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardAsset : MonoBehaviour
{
    private Transform Cam;
    private void Start()
    {
        Cam = GameObject.Find("Cam").transform;
    }
    void LateUpdate()
    {
        transform.LookAt(Cam);
    }
}
