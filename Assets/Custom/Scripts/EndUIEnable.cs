using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUIEnable : MonoBehaviour
{
    public GameObject EndUI;
    public void EnableEndUI()
    {
        EndUI.SetActive(true);
    }
}
