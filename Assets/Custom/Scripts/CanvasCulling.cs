using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCulling : MonoBehaviour
{
    private Transform CamPos;
    void Start()
    {
        CamPos = GameObject.Find("Cam").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Mathf.Abs(Vector3.Distance(CamPos.position, transform.position)) > 100)
        {
            transform.Find("Canvas").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("Canvas").gameObject.SetActive(true);
        }
    }
}
