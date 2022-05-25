using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundEnemy : MonoBehaviour
{
    public float WalkSpeed = 1;
    public float StartHealth = 5;
    private float Health = 5;
    public float StunTime = 1.5f;
    public float Gravity = -15f;

    public Transform HealthMeter;
    public GameObject Sprite;

    public float StunDelay;
    public int direction = -1;
    private bool dead;
    private Vector3 StartPos;
    private bool Grounded;

    private void Awake()
    {
        StartPos = transform.position;
        Health = StartHealth;
    }
    void LateUpdate()
    {
        if (!dead)
        {
            Sprite.SetActive(true);
            if (StunDelay <= 0 && Grounded)
            {
                transform.Translate(new Vector2(direction, 0) * Time.deltaTime * WalkSpeed);
            }
            else
            {
                StunDelay -= Time.deltaTime;
            }
            if (!Grounded)
            {
                this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, Gravity), ForceMode2D.Force);
            }

            HealthMeter.localScale = new Vector3(Mathf.Clamp01(Health), 1, 1);
        }
        else
        {
            Sprite.SetActive(false);
        }
    }

    public void Hurt(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Die();
        }
        StunDelay = StunTime;
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 200), ForceMode2D.Force);
    }
    public void Die()
    {
        //Destroy(this);
        this.gameObject.SetActive(false);
    }
    public void Stun(float s)
    {
        StunDelay = s;
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 200), ForceMode2D.Force);
    }
    public void Revive()
    {
        this.gameObject.SetActive(true);
        dead = false;
        transform.localPosition = StartPos;
        Health = StartHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            Grounded = true;
        }
    }
    public void Floor(int f)
    {
        Grounded = Convert.ToBoolean(f);
    }
}
