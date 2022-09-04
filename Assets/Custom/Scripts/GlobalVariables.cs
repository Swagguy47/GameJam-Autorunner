using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int GameDifficulty;
    //0 = easy
    //1 = medium
    //2 = hard
    //3 = endless

    public static bool EasySaved;
    public static bool MediumSaved;
    public static bool HardSaved;
    public static bool EndlessSaved;

    private void Start()
    {
        
    }
}
