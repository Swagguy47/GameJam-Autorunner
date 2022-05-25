using UnityEngine;

public class CorpseGrounder : MonoBehaviour
{
    public bool Grounded;

    private Transform CamPos;
    private void Start()
    {
        CamPos = GameObject.Find("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Grounded = true;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, CamPos.position) < 30)
        {

            if (!Grounded)
            {
                transform.Translate(new Vector2(0, -5) * Time.deltaTime);
            }
            else
            {
                Destroy(this.GetComponent<BoxCollider2D>());
                Destroy(this);
            }
        }
    }
}
