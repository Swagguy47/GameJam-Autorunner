using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyGO;

    private void Awake()
    {
        GameObject.Find("-GameLogic-").GetComponent<GameLogic>().AllEnemies.Add(this);
    }

    public void Revive()
    {
        this.gameObject.SetActive(true);
        if (EnemyGO.GetComponent<GroundEnemy>() != null)
        {
            EnemyGO.GetComponent<GroundEnemy>().Revive();
        }
        else if (EnemyGO.GetComponent<FlyingEnemy>() != null)
        {
            EnemyGO.GetComponent<FlyingEnemy>().Revive();
        }
        else
        {
            Debug.LogWarning("WAS UNABLE TO REVIVE ENEMY " + this.name + " \nCouldn't find GroundEnemy or FlyingEnemy script");
        }
    }

    public void Hurt(float InputDamage)
    {
        if (EnemyGO.GetComponent<GroundEnemy>() != null)
        {
            EnemyGO.GetComponent<GroundEnemy>().Hurt(InputDamage);
        }
        else if (EnemyGO.GetComponent<FlyingEnemy>() != null)
        {
            EnemyGO.GetComponent<FlyingEnemy>().Die();
            GameObject.Find("-GameLogic-").GetComponent<GameLogic>().AddEnemyKill();
        }
        else
        {
            Debug.LogWarning("WAS UNABLE TO HURT ENEMY " + this.name + " \nCouldn't find GroundEnemy or FlyingEnemy script");
        }
    }

    public void Die()
    {
        if (EnemyGO.GetComponent<GroundEnemy>() != null)
        {
            EnemyGO.GetComponent<GroundEnemy>().Die();
        }
        else if (EnemyGO.GetComponent<FlyingEnemy>() != null)
        {
            EnemyGO.GetComponent<FlyingEnemy>().Die();
        }
        else
        {
            Debug.LogWarning("WAS UNABLE TO KILL ENEMY " + this.name + " \nCouldn't find GroundEnemy or FlyingEnemy script");
        }
    }
}
