using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousBestLabel : MonoBehaviour
{
    public Transform Player;
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, Player.position.y /1000, 0);
    }
}
