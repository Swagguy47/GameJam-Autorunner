using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineMarker : MonoBehaviour
{
    public Transform TrackedObject;
    public float DifficultyMult = 1;

    private Image ThisImage;
    private void Start()
    {
        ThisImage = this.GetComponent<Image>();
    }
    void Update()
    {
        transform.localPosition = new Vector3(((TrackedObject.position.x / 10) / DifficultyMult) -50, 0, 0.01f);

        //Out Of Range Culling
        if (transform.localPosition.x < -50 || transform.localPosition.x > 50)
        {
            ThisImage.enabled = false;
        }
        else
        {
            ThisImage.enabled = true;
        }
    }
}
