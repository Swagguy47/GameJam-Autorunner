using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmBox : MonoBehaviour
{
    private int EvoInt;
    public TMPro.TextMeshProUGUI TextBox;
    public void Refresh(int EvoNum)
    {
        EvoInt = EvoNum;
        SimulateStats();
        //TextBox.text = 
    }

    public void SimulateStats()
    {
        GameObject.Find("Evo" + EvoInt).GetComponent<EvoSelection>().Buff = 0;
    }
}
