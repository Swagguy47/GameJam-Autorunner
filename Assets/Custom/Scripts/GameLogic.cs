using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public GameObject PostGameUI;
    public TMPro.TextMeshProUGUI Header;
    public TMPro.TextMeshProUGUI DistanceLabel;
    public RenderTexture RenderTex;
    public List<EvoSelection> EvoCards;
    public float BestPos;
    public bool ConfirmDeath;
    public TMPro.TextMeshProUGUI StatLabel;

    public GameObject Camera;

    public GameObject FireWall;

    public PlayerController Player;

    public EvoCard EvoTemplate;

    public List<Enemy> AllEnemies;

    public int GenerationNum = 1;

    public float LevelTime;

    public float GenerationTime;

    public int TotalKills;

    public int GenerationKills;

    private float RespawnDelay =  1.18f;

    public DeathCinematicTriggers DeathCine;

    private void Update()
    {
        LevelTime += Time.deltaTime;
        GenerationTime += Time.deltaTime;
    }

    public void AddEnemyKill()
    {
        TotalKills += 1;
        GenerationKills += 1;
    }

    public void Death(float lastPos)
    {
        GenerationTime = 0;
        GenerationKills = 0;
        DeathCine.SetScene(-1);
        RespawnDelay = 1.18f;
        ConfirmDeath = true;
        PostGameUI.SetActive(true);
        //PostGameUI.GetComponent<Animation>().Play();
        if (lastPos > BestPos)
        {
            Header.text = "NEW FURTHEST DISTANCE!";
            DistanceLabel.text = "Old: " + BestPos + " New: " + lastPos + " meters!";
            BestPos = lastPos;
        }
        else
        {
            Header.text = "Better luck next time!";
            DistanceLabel.text = "Best: " + BestPos + " Last: " + lastPos + " meters!";
        }

        RefreshCards();
    }

    public void StartRevive(int Evo)
    {
        if (Player.Dead)
        {
            GenerationTime = 0;
            //-------------------------------------------
            //BUFFS
            //-------------------------------------------
            if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 0)//More Health
            {
                if (Player.HealthReset < 12)
                {
                    Player.HealthReset += 1;
                }
                //TODO
                //_______________________________________________________________
                //YOU JUST CHANGED EYESIGHT TO HEALTH
                //YOU'RE ADDING CONFIRM BOXES TO THE NEW UPGRADE MENU
                //YEAH
                //_______________________________________________________________


            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 1)//Higher Jump
            {
                if (Player.JumpForce < 1200)
                {
                    Player.JumpForce += 200f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 2)//Increased Bumpiness
            {
                Player.Bumpiness += 0.5f;
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 3)//Better Air Control
            {
                if (Player.gameObject.GetComponent<Rigidbody2D>().drag > 0.1)
                {
                    Player.gameObject.GetComponent<Rigidbody2D>().drag -= 0.1f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 4)//Shorter Stuns
            {
                Player.StunFactor += 0.25f;
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 5)//Lighter Armor
            {
                if (Player.Gravity < -5)
                {
                    Player.Gravity += 5f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 6)//Shorter Cooldown
            {
                if (Player.ItemCooldownReset > 0f)
                {
                    Player.ItemCooldownReset -= 1;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 7)//Faster Attack Speed
            {
                if (Player.MeleeReset > 0f)
                {
                    Player.MeleeReset -= 0.25f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Buff == 8)//Longer Sword
            {
                if (Player.MeleeDistance < 3f)
                {
                    Player.MeleeDistance += 0.25f;
                }
            }

            //-------------------------------------------
            //NERFS
            //-------------------------------------------
            if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 0)//Less Health
            {
                if (Player.HealthReset > 1)
                {
                    Player.HealthReset -= 1;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 1)//Lower Jump
            {
                if (Player.JumpForce > 250)
                {
                    Player.JumpForce -= 200f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 2)//Decreased Bumpiness
            {
                if (Player.Bumpiness > 0)
                {
                    Player.Bumpiness -= 0.5f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 3)//Worse Air Control
            {
                if (Player.gameObject.GetComponent<Rigidbody2D>().drag < 1.2)
                {
                    Player.gameObject.GetComponent<Rigidbody2D>().drag += 0.1f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 4)//Longer Stuns
            {
                Player.StunFactor -= 0.25f;
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 5)//Heavier Armor
            {
                if (Player.Gravity > 15)
                {
                    Player.Gravity -= 5f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 6)//Longer Cooldown
            {
                if (Player.ItemCooldownReset < 5)
                {
                    Player.ItemCooldownReset += 1;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 7)//Slower Attack Speed
            {
                if (Player.MeleeReset < 2f)
                {
                    Player.MeleeReset += 0.25f;
                }
            }
            else if (GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Nerf == 8)//Shorter Sword
            {
                if (Player.MeleeDistance > 0.5f)
                {
                    Player.MeleeDistance -= 0.25f;
                }
            }

            //-------------------------------------------

            Camera.SetActive(true);
            GenerationNum++;
            GameObject.Find("GenerationCount").GetComponent<TMPro.TextMeshProUGUI>().text = "Generation: " + GenerationNum;
            FireWall.transform.position = new Vector3(-70, 2, 0);
            //Player.Revive();
            Player.Grounded = true;
            Player.Item = GameObject.Find("Evo" + Evo).GetComponent<EvoSelection>().Item + 1;
            Player.Revive();
            ConfirmDeath = false;
            foreach (Enemy CurrentEnemy in AllEnemies)
            {
                if (CurrentEnemy != null)
                {
                    CurrentEnemy.Revive();
                }
            }
        }
    }

    private void RefreshCards()
    {
        foreach (EvoSelection Card in EvoCards)
        {
            Card.Buff = Random.Range(0, EvoTemplate.Buffs.Count);
            Card.Nerf = Random.Range(0, EvoTemplate.Nerfs.Count);
            if (Card.Nerf == Card.Buff)
            {
                Debug.Log("Nerf was the same, corrected");
                while (Card.Nerf == Card.Buff)
                {
                    Card.Nerf = Random.Range(0, EvoTemplate.Nerfs.Count);
                }
            }
            Card.Item = Random.Range(0, EvoTemplate.Items.Count);
            Card.RefreshUI();
        }
    }
}
