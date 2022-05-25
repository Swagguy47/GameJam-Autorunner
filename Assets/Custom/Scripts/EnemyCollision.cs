using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float Damage = 1;
    public Transform EnemyRoot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && EnemyRoot.GetComponent<GroundEnemy>().StunDelay! >= 0)
        {
            collision.GetComponent<PlayerController>().Hurt(Damage);
            EnemyRoot.GetComponent<GroundEnemy>().Stun(2);
        }
        else if (collision.tag == "Environment")
        {
            if (EnemyRoot.localScale.x == 1)
            {
                EnemyRoot.localScale = new Vector3(-1, EnemyRoot.localScale.y, EnemyRoot.localScale.z);
                EnemyRoot.GetComponent<GroundEnemy>().direction = 1;
            }
            else
            {
                EnemyRoot.localScale = new Vector3(1, EnemyRoot.localScale.y, EnemyRoot.localScale.z);
                EnemyRoot.GetComponent<GroundEnemy>().direction = -1;
            }
        }
    }
}
