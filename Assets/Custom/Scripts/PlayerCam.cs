using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 2 * player.gameObject.GetComponent<PlayerController>().gravitySwap, transform.position.z);
        //transform.LookAt(player);
    }
}
