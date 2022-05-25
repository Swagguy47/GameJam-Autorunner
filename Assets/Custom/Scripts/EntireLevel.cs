using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireLevel : MonoBehaviour
{
    public List<int> CurrentLevel;
    public GameObject[] Modules;
    public GameObject[] DecendingModules;
    public bool DEBUG;
    public GameObject DebugModule;

    private int GroundLevel = 0;
    private GameObject CurrentModule;
    private GameObject CurrentFlipModule;
    private Vector3 ModulePos;
    private Vector3 FlipModulePos;

    void Awake()
    {
        CurrentLevel.Add(Mathf.RoundToInt(Random.Range(0, Modules.Length))); //Generate First Module
        //new GameObject("-ModuleTarget-");
        GenerateModule();
    }

    public void ToggleDebug(bool NewDebug)
    {
        DEBUG = NewDebug;
    }

    public void GenerateModule()
    {
        if (GameObject.Find("-ModuleTarget-") != null)
        {
            ModulePos = GameObject.Find("-ModuleTarget-").transform.position;

            Destroy(GameObject.Find("-ModuleTarget-"));
            

            if (!DEBUG)
            {
                if (GroundLevel < 6)
                {
                    CurrentLevel.Add(Mathf.RoundToInt(Random.Range(0, Modules.Length)));

                    CurrentModule = Instantiate(Modules[CurrentLevel[CurrentLevel.Count - 1]]);
                    Debug.Log("NORMAL " + GroundLevel);
                }
                else
                {
                    CurrentLevel.Add(Mathf.RoundToInt(Random.Range(0, DecendingModules.Length)));

                    CurrentModule = Instantiate(DecendingModules[CurrentLevel[CurrentLevel.Count - 1]]);
                    Debug.Log("DECENDING " + GroundLevel);
                }
            }
            else
            {
                CurrentModule = Instantiate(DebugModule);
            }
            //Finding new ground level
            if (!DEBUG)
            {
                GroundLevel += CurrentModule.transform.Find("Canvas").transform.Find("LoadTrig").gameObject.GetComponent<ModuleLoadTrig>().LevelIncrease;
            }

            CurrentModule.transform.position = ModulePos;

            if (!DEBUG)//CeilingStuff
            {
                FlipModulePos = new Vector3(ModulePos.x, 39 - (ModulePos.y), ModulePos.z);

                if (GroundLevel < 6)
                {
                    CurrentFlipModule = Instantiate(Modules[CurrentLevel[CurrentLevel.Count - 1]]);
                }
                else
                {
                    CurrentFlipModule = Instantiate(DecendingModules[CurrentLevel[CurrentLevel.Count - 1]]);
                }
                CurrentFlipModule.transform.position = FlipModulePos;
                CurrentFlipModule.transform.localScale = new Vector3(1, -1, 1);
                CurrentFlipModule.transform.Find("Canvas").transform.Find("-ModuleTarget-").name = "-FlipModuleTarget-";
                Destroy(CurrentFlipModule.transform.Find("Canvas").transform.Find("LoadTrig").gameObject);
            }
        }
    }
}
