using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public MobileControl MobileControl;
    
    public float DifficultyDistance = 1000;
    
    public float Gravity = -9.81f;
    public float JumpForce = 10f;
    public float Bumpiness = 1f;
    public float StunFactor = 1f;
    public int Item = 0;
    public float ItemCooldownReset = 1f;
    public float MeleeReset = 1;
    public float MeleeDistance = 1;

    public GameObject StunMeter;
    public Transform StunRoot;
    public GameObject ItemMeter;
    public Transform ItemRoot;
    public Transform AttackRoot;
    public Transform SwordBlade;

    public bool Stunned = true;

    public SpriteRenderer KnightSprite;
    public Sprite[] Sprites;

    public BoxCollider2D FrontCollider;
    public BoxCollider2D FloorCollider;
    public GameObject CorpseModule;
    public GameObject TpModule;

    public bool Grounded;
    public bool Dead;
    public GameObject LeadFX;
    public Animator MeshAnimator;
    public GameObject Portal;
    public bool Finished;
    private float MeleeDelay;

    public float Health = 3;
    public float HealthReset = 3;
    private bool Teleport;
    private bool SecondJump;
    private GameObject LastCorpse;
    private GameObject Teleporter;
    public ParticleSystem TPFX;

    public float StunTime = 2f;
    public float CooldownTime = 1f;
    private ConstantForce2D SelfForce;
    private Rigidbody2D SelfRB;
    public int gravitySwap = 1;
    private bool AgainstBackwall;
    private float StunStartTime;

    private Image KnightIcon;
    public List<Sprite> KnightIcons;

    private TMPro.TextMeshProUGUI DistanceCounter;

    private void Awake()
    {
        SelfForce = this.GetComponent<ConstantForce2D>();
        SelfRB = this.GetComponent<Rigidbody2D>();
        KnightIcon = GameObject.Find("KnightIcon").GetComponent<Image>();
        DistanceCounter = GameObject.Find("Distance").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            //SceneManager.LoadScene("MainMenu");
        //}

        UpdateAnimator();

        if (!Dead && !Stunned && Finished)
        {
            //Grounded = true;
            //SelfRB.velocity = new Vector2(12, SelfRB.velocity.y);
        }


        if (!Dead)
        {
            DistanceCounter.text = Mathf.Abs(Mathf.RoundToInt(transform.position.x)) + " Meters";
            if (Mathf.RoundToInt(transform.position.x) >= DifficultyDistance)
            {
                GameObject.Find("CurrentLevel").GetComponent<EntireLevel>().DEBUG = true;
            }
            if (MeleeDelay <= 0 && !Stunned)
            {
                if (MobileControl.Attack)//|| Input.GetMouseButtonDown(0)) PC Mouse Controls
                {
                    MeleeDelay = MeleeReset;
                    Attack();
                }
            }
            else
            {
                MeleeDelay -= Time.deltaTime;
            }
            
            if (transform.position.x > GameObject.Find("-GameLogic-").GetComponent<GameLogic>().BestPos)
            {
                GameObject.Find("GoalLine").transform.position = new Vector3(-100, 0, 0);
                LeadFX.SetActive(true);
                KnightIcon.sprite = KnightIcons[1];
            }

            if (CooldownTime <= 0) //Items
            {
                if (Grounded)
                {
                    SecondJump = true;
                }
                ItemMeter.SetActive(false);
                if (MobileControl.Ability && Item != 2)
                {
                    Debug.Log("LShift");
                    if (Item != 0)
                    {
                        CooldownTime = ItemCooldownReset;
                    }
                    if (Item == 1)//Dash
                    {
                        Debug.Log("DASH");
                        if (Grounded)
                        {
                            Stunned = true;
                            StunTime = 0.5f;
                            Stunned = true;
                            if (ItemCooldownReset <= 0)
                            {
                                CooldownTime = 0.15f;
                            }
                            SelfRB.AddForce(new Vector2(JumpForce * 1.5f, 2), ForceMode2D.Force);
                        }
                        else
                        {
                            SelfRB.AddForce(new Vector2(JumpForce * 1.5f, 0), ForceMode2D.Force);
                        }
                        
                    }
                    if (Item == 3)//Teleport
                    {
                        Debug.Log("TELEPORT");
                        TPFX.Play();
                        CooldownTime = ItemCooldownReset;

                        transform.position = Portal.transform.position;
                        Stunned = true;
                        StunTime = 1;
                        Stunned = true;
                        SelfRB.velocity = new Vector2(0, 0);
                        Portal.GetComponent<PortalFollower>().storedPositions.Clear();
                        TPFX.Stop();

                        //if (Teleport)
                        //{
                        //    transform.position = Teleporter.transform.position;
                        //    Destroy(Teleporter);
                        //    StunTime = 1;
                        //    Stunned = true;
                        //    StunTime = 1;
                        //    SelfRB.velocity = new Vector3(0, 0, 0);
                        //    Teleport = false;
                        //}
                        //else
                        //{
                        //    CooldownTime /= 2;
                        //    Teleporter = Instantiate(TpModule);
                        //    Teleporter.transform.position = transform.position;
                        //    Teleport = true;
                        //}

                    }
                    if (Item == 4)//Slam
                    {
                        Debug.Log("SLAM");
                        SelfRB.AddRelativeForce(new Vector2(0, -800), ForceMode2D.Force);
                        StunTime = 0.75f;
                        Stunned = true;
                        StunTime = 0.75f;
                    }
                    if (Item == 5)//Grav Inverter
                    {
                        Debug.Log("GRAV");
                        if (gravitySwap == 1)
                        {
                            gravitySwap = -1;
                            this.GetComponent<Animator>().SetBool("AntiGrav", true);
                            //GameObject.Find("Cam").GetComponent<Animator>().SetBool("AntiGrav", true);
                        }
                        else
                        {
                            gravitySwap = 1;
                            this.GetComponent<Animator>().SetBool("AntiGrav", false);
                            //GameObject.Find("Cam").GetComponent<Animator>().SetBool("AntiGrav", false);
                        }
                    }
                    if (Item == 6)//BackDash
                    {
                        Debug.Log("BACKDASH");
                        if (Grounded)
                        {
                            Stunned = true;
                            StunTime = 0.5f;
                            Stunned = true;

                            if (ItemCooldownReset <= 0)
                            {
                                CooldownTime = 0.15f;
                            }

                            SelfRB.AddForce(new Vector2(-JumpForce * 1.5f, 2), ForceMode2D.Force);
                        }
                        else
                        {
                            Stunned = true;
                            StunTime = 0.5f;
                            Stunned = true;
                            SelfRB.AddForce(new Vector2(-JumpForce * 2, 0), ForceMode2D.Force);
                        }
                    }
                }
                else if (MobileControl.Jump && Item == 2 && Grounded == false && SecondJump == true && !Dead)//Double jump
                {
                    Debug.Log("DOUBLE JUMP");
                    SecondJump = false;
                    if (SelfRB.velocity.y * gravitySwap < 0)
                    {
                        SelfRB.velocity = new Vector2(SelfRB.velocity.x + 3, 0);
                    }
                    SelfRB.AddRelativeForce(new Vector2(3, JumpForce), ForceMode2D.Force);
                }
            }
            else
            {
                ItemMeter.SetActive(true);
                ItemRoot.localScale = new Vector3(Mathf.InverseLerp(0, 1, CooldownTime), 1, 1);
                CooldownTime -= Time.deltaTime;
            }

            if (!Stunned)
            {

                StunMeter.SetActive(false);
                StunRoot.localScale = new Vector3(0, 1, 1);

                KnightSprite.sprite = Sprites[0];

                if (Grounded && !Stunned && !Dead)
                {
                    SelfRB.velocity = new Vector2(12, SelfRB.velocity.y);
                }
                SelfForce.force = new Vector2(0, Gravity * gravitySwap); //Gravity
                if (MobileControl.Jump && Grounded && !Dead)
                {
                    SelfRB.AddRelativeForce(new Vector2(0, JumpForce), ForceMode2D.Force);
                    Debug.Log("Jump");
                }
            }
            else
            {
                StunMeter.SetActive(true);
                StunRoot.localScale = new Vector3(Mathf.InverseLerp(0, 1, StunTime), 1, 1);

                KnightSprite.sprite = Sprites[1];
                SelfForce.force = new Vector2(0, Gravity * gravitySwap);
                //SelfRB.velocity = new Vector2(0, SelfRB.velocity.y);

                if (StunTime > 0f && Stunned)
                {
                    StunTime -= Time.deltaTime;
                }
                else if (StunTime > -100f && StunTime <= 0 || !Stunned)
                {
                    Stunned = false;
                    StunTime = -100f;
                }
            }
        }
    }

    public void Stun(int s)
    {
        StunStartTime = s;
        //S = float, stun time (S should be set to 1 as well) (If stun is just toggle set -100 when activate stun)
        StunTime = (s / StunFactor);
        if (StunTime > 0)
        {
            Stunned = true;
            SelfRB.AddForce(new Vector2(-500, 250), ForceMode2D.Force);
        }
    }

    public void Knockback()//For when you collide with wall
    {
        Stun(2);
        SelfRB.AddForce(new Vector2(-150 * Bumpiness, 100 * Bumpiness), ForceMode2D.Force);
        Debug.Log("Bump!");
    }
    public void Floor(int f)
    {
        if (!Dead)
        {
            Grounded = Convert.ToBoolean(f);
        }
    }
    public void Backwall(int b)
    {
        AgainstBackwall = Convert.ToBoolean(b);
    }

    public void Die()
    {
        if (Stunned == false)
        {
            Stunned = false;
            StunTime = 0;
            Stunned = false;
            //GameObject.Find("Cam").GetComponent<Animator>().SetBool("AntiGrav", false);
            if (Mathf.RoundToInt(transform.position.x) > GameObject.Find("-GameLogic-").GetComponent<GameLogic>().BestPos)
            {
                GameObject.Find("GoalLine").transform.position = transform.position;
            }
            else
            {
                //Failsafe in case you die behind your previous best after passing it originally.
                GameObject.Find("GoalLine").transform.position = new Vector3(GameObject.Find("-GameLogic-").GetComponent<GameLogic>().BestPos, 0, 0);
            }
            Dead = true;
            LastCorpse = Instantiate(CorpseModule);
            SelfRB.velocity = new Vector3(0, 0, 0);
            LastCorpse.transform.position = transform.position;
            KnightSprite.enabled = false;

            GameObject.Find("-GameLogic-").GetComponent<GameLogic>().Death(Mathf.RoundToInt(transform.position.x));
            if (GameObject.Find("Cam") != null)
            {
                GameObject.Find("Cam").SetActive(false);
            }
            transform.position = new Vector3(0, 1.5f, 0);
            gravitySwap = 1;
            //this.GetComponent<Animator>().SetBool("AntiGrav", false);
        }
        else
        {
            Stunned = false;
            StunTime = 0;
            Stunned = false;
            Die();
            Debug.LogWarning("Died While Stunned\nLookout for infinite revive bug");
        }
    }
    public void Revive()
    {
        Debug.Log("Revive Called");
        if (Dead && GameObject.Find("-GameLogic-").GetComponent<GameLogic>().ConfirmDeath)
        {
            //GameObject.Find("Cam").GetComponent<Animator>().SetTrigger("FadeOut");
            AttackRoot.localScale = new Vector3(MeleeDistance, MeleeDistance / 2, 1);
            SwordBlade.localScale = new Vector3(1, MeleeDistance, MeleeDistance);//incriment by 0.25
            KnightIcon.sprite = KnightIcons[0];
            GameObject.Find("Cam").GetComponent<Animator>().SetBool("AntiGrav", false);
            LeadFX.SetActive(false);
            UpdateAnimator();
            Health = HealthReset;
            Dead = false;
            KnightSprite.enabled = true;
            StunTime = 3;
            Stunned = true;//BugFest Stuns when jump after respawn
            StunTime = 3;
            Grounded = true;
            GameObject.Find("Cam").SetActive(true);
            CooldownTime = ItemCooldownReset;
            gravitySwap = 1;
            Teleport = false;
            Destroy(Teleporter);
            this.GetComponent<Animator>().SetBool("AntiGrav", false);
            SelfRB.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 1.5f, 0);
            SecondJump = false;
            MeleeDelay = 0f;
            Health = HealthReset;
            Portal.GetComponent<PortalFollower>().storedPositions.Clear();
            Portal.transform.position = new Vector3(0, 1, 0);
            if (Item == 3)
            {
                Portal.SetActive(true);
            }
            else
            {
                Portal.SetActive(false);
            }
        }
    }

    public void UpdateAnimator()
    {
        //Particle Stuff
        if (AgainstBackwall && Stunned! && Stunned)
        {
            //GameObject.Find("ImpactPuffFXBack").GetComponent<ParticleSystem>().Play();
        }
        else
        {
            //GameObject.Find("ImpactPuffFXBack").GetComponent<ParticleSystem>().Stop();
        }

        if (MeleeDistance > 1.5f)
        {
            MeshAnimator.SetBool("Heavy", true);
        }
        else
        {
            MeshAnimator.SetBool("Heavy", false);
        }

        //Debug.Log("Stunned" + Stunned);
        if (Stunned)
        {
            MeshAnimator.SetBool("Stunned", true);
            MeshAnimator.SetFloat("StunTime", StunStartTime + StunTime);
            //Debug.Log("StunTime:" + (StunStartTime + StunTime));
        }
        else
        {
            MeshAnimator.SetBool("Stunned", false);
        }
        MeshAnimator.SetBool("Grounded", Grounded);
        MeshAnimator.SetBool("BackWall", AgainstBackwall);
    }

    public void Hurt(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Die();
        }
        else
        {
            //Stun(1);
            Knockback();
        }
    }

    private void Attack()
    {
        MeshAnimator.SetInteger("AttackInt", Mathf.RoundToInt(UnityEngine.Random.Range(0, 2)));
        MeshAnimator.SetTrigger("Attack");
    }
}
