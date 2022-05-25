using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpDetection : MonoBehaviour
{
    public PlayerController PlayerBrain;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Environment" && !PlayerBrain.Stunned && collision.gameObject.layer != 6)
        {
            PlayerBrain.Knockback();
        }
    }
}
