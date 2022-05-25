using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerController>().Dead)
            {
                collision.gameObject.GetComponent<PlayerController>().Die();
            }
        }
    }
}
