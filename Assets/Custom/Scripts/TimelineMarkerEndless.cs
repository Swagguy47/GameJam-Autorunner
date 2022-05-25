using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineMarkerEndless : MonoBehaviour
{
    public Transform TrackedObject;

    private Image ThisImage;
    private GameLogic Brain;
    private Transform PlayerPos;
    private float TrackedPos;
    private void Start()
    {
        ThisImage = this.GetComponent<Image>();
        Brain = GameObject.Find("-GameLogic-").GetComponent<GameLogic>();
        PlayerPos = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (TrackedPos < Brain.BestPos)
        {
            TrackedPos = Brain.BestPos;
        }
        
        if (Brain.BestPos < PlayerPos.position.x)
        {
            TrackedPos = PlayerPos.position.x;
            transform.localPosition = new Vector3(50, 0, 0.01f);
        }
        else
        {
            transform.localPosition = new Vector3((((TrackedObject.position.x / 10) / 0.001f) / TrackedPos) - 50, 0, 0.01f);
        }

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
