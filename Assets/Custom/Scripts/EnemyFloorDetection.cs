using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloorDetection : MonoBehaviour
{
    private int Collisions;
    public GroundEnemy EnemyBrain;
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
            EnemyBrain.Floor(1);
        }
        else
        {
            EnemyBrain.Floor(0);
        }
    }
}
