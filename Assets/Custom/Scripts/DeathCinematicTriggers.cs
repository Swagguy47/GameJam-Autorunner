using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCinematicTriggers : MonoBehaviour
{
    public Animator DeathCam;
    public Animator DeathKnight;

    public void SetScene(int NewScene)
    {
        DeathCam.SetInteger("Scene", NewScene);
        DeathKnight.SetInteger("Scene", NewScene);
    }
}
