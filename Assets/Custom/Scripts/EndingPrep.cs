using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class EndingPrep : MonoBehaviour
{
    private PlayerController Player;
    private GameLogic Logic;
    private TMPro.TextMeshProUGUI StatsLabel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            Logic = GameObject.Find("-GameLogic-").GetComponent<GameLogic>();
            StatsLabel = Logic.StatLabel;
            Player = GameObject.Find("Player").GetComponent<PlayerController>();

            StatsLabel.text = "Stats:\n\nGeneration: " + Logic.GenerationNum + "\n\nGeneration Finish Time: " + Logic.GenerationTime + "\n\nTotal Level Finish Time: " + Logic.LevelTime + "\n\nEnemy Kills This Generation: " + Logic.GenerationKills + "\n\nTotal Enemy Kills: " + Logic.TotalKills + "\n\nRemaining HP: " + Player.Health;

            Player.gravitySwap = 1;
            Player.gameObject.GetComponent<Animator>().SetBool("AntiGrav", false);
            Player.CooldownTime = 999999999999999999;
            Player.gameObject.GetComponent<Rigidbody2D>().drag = 2;
            Player.Finished = true;
            Player.JumpForce = 0;
            GameObject.Find("FireModule").GetComponent<FireWall>().Moving = false;

            GameObject.Find("Cam").GetComponent<Animator>().SetInteger("EndScene", 1);
            GameObject.Find("Cam").GetComponent<PlayerCam>().enabled = false;
            GameObject.Find("Cam").transform.parent = Player.transform;
            GameObject.Find("PostProcessingMain").GetComponent<PostProcessVolume>().weight = 0;
            GameObject.Find("PostProcessingCine").GetComponent<PostProcessVolume>().weight = 1;
        }
    }
}
