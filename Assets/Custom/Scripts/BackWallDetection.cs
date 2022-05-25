using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWallDetection : MonoBehaviour
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
            PlayerBrain.Backwall(1);
            
        }
        else
        {
            PlayerBrain.Backwall(0);
        }
    }
}
