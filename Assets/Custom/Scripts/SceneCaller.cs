using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCaller : MonoBehaviour
{
    public DeathCinematicTriggers DeathCine;

    public void SetScene(int Scene)
    {
        DeathCine.SetScene(Scene);
    }
}
