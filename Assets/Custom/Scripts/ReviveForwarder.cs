using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveForwarder : MonoBehaviour
{
    public GameLogic GameLogicGO;
    public CardSelectScreen CardSelect;
    public Animator Knight;
    public Animator Cam;
    private int EvoNum;
    public void CallRevive()
    {
        GameLogicGO.StartRevive(EvoNum);
        CardSelect.Disappear();
        Knight.SetInteger("Scene", -1);
        Cam.SetInteger("Scene", -1);
    }
    public void SetEvoNum(int NewEvo)
    {
        EvoNum = NewEvo;
    }
}
