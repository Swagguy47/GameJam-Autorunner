using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleLoadTrig : MonoBehaviour
{
    public int LevelIncrease;
    public GameObject ModuleTarget;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            GameObject.Find("CurrentLevel").GetComponent<EntireLevel>().GenerateModule();
            Destroy(ModuleTarget);
            Destroy(this.gameObject);
        }
    }
}
