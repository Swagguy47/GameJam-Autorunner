using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyType;
    public int RangeMax = 10;
    private GameObject EnemyThing;
    void Start()
    {
        if (Mathf.RoundToInt(Random.Range(0, RangeMax)) == 1)
        {
            EnemyThing = Instantiate(EnemyType);
            EnemyThing.transform.position = transform.position;
            EnemyThing.transform.parent = GameObject.Find("PlayerModule").transform.Find("Canvas").transform;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
