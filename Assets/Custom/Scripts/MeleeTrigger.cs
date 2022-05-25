using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<FlyingEnemy>() != null)
            {
                collision.gameObject.GetComponent<FlyingEnemy>().Die();
            }

            else if (collision.gameObject.GetComponent<GroundEnemy>() != null)
            {
                collision.gameObject.GetComponent<GroundEnemy>().Hurt(1);
            }

            else if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                collision.gameObject.GetComponent<FlyingEnemy>().Die();
            }
        }
    }
}
