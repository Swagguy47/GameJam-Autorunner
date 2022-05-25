using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public float Speed;
    public bool Moving;
    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            transform.Translate(transform.right * Speed * Time.deltaTime); //movement

            if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) > 50)
            {
                transform.position = new Vector3(GameObject.Find("Player").transform.position.x - 48, transform.position.y, -1); //Out of range alignment
            }
        }
        transform.position = new Vector3(transform.position.x, GameObject.Find("Player").transform.position.y - 5, -1); // vertical alignment
    }
}
