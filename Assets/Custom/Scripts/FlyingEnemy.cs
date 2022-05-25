using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float Damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().Hurt(Damage);
            this.GetComponent<Animator>().SetBool("Dead", true);
        }
    }

    public void Revive()
    {
        this.GetComponent<Animator>().SetBool("Dead", false);
    }

    public void Die()
    {
        Debug.Log("AddKill");
        this.GetComponent<Animator>().SetBool("Dead", true);
        GameObject.Find("-GameLogic-").GetComponent<GameLogic>().AddEnemyKill();
    }
}
