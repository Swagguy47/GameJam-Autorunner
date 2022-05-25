using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegister : MonoBehaviour
{
    public List<Enemy> LevelEnemies;
    private void Awake()
    {
        foreach (Enemy ThisEnemy in LevelEnemies)
        {
            GameObject.Find("-GameLogic-").GetComponent<GameLogic>().AllEnemies.Add(ThisEnemy);
        }
        Destroy(this);
    }
}
