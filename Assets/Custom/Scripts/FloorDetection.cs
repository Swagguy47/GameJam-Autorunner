using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    private int Collisions;
    public PlayerController PlayerBrain;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Environment")
        {
            Collisions++;
            SendResults();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Environment")
        {
            Collisions--;
            SendResults();
        }
    }

    private void SendResults()
    {
        if (Collisions > 0)
        {
            PlayerBrain.Floor(1);
        }
        else
        {
            PlayerBrain.Floor(0);
        }
    }
}
