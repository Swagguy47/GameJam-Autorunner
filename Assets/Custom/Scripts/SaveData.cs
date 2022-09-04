using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //Saved progress for endless high scores, coins, and quick resume data

    public float EndlessRecord; //Furthest endless distance
    public int Coins;

    //These are to be checked prior to prompting the player if they want to resume from save at main menu
    //if false it means they have no valid saves for that difficulty yet, and should skip the prompt
    public bool SaveEasyUsed;
    public bool SaveMediumUsed;
    public bool SaveHardUsed;
    public bool SaveEndlessUsed;

    //Easy Quick Resume
    public float SaveGravityEasy;
    public float SaveJumpEasy;
    public float SaveBumpEasy;
    public float SaveStunEasy;
    public float SaveItemEasy;
    public float SaveCooldownEasy;
    public float SaveAttackSpeedEasy;
    public float SaveSwordDistanceEasy;
    public float SaveHealthEasy;
    public float SaveDistanceEasy;

    //Medium Quick Resume
    public float SaveGravityMedium;
    public float SaveJumpMedium;
    public float SaveBumpMedium;
    public float SaveStunMedium;
    public float SaveItemMedium;
    public float SaveCooldownMedium;
    public float SaveAttackSpeedMedium;
    public float SaveSwordDistanceMedium;
    public float SaveHealthMedium;
    public float SaveDistanceMedium;

    //Hard Quick Resume
    public float SaveGravityHard;
    public float SaveJumpHard;
    public float SaveBumpHard;
    public float SaveStunHard;
    public float SaveItemHard;
    public float SaveCooldownHard;
    public float SaveAttackSpeedHard;
    public float SaveSwordDistanceHard;
    public float SaveHealthHard;
    public float SaveDistanceHard;

    //Endless Quick Resume
    public float SaveGravityEndless;
    public float SaveJumpEndless;
    public float SaveBumpEndless;
    public float SaveStunEndless;
    public float SaveItemEndless;
    public float SaveCooldownEndless;
    public float SaveAttackSpeedEndless;
    public float SaveSwordDistanceEndless;
    public float SaveHealthEndless;
    public float SaveDistanceEndless;
}
