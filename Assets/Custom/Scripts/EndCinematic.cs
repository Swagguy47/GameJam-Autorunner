using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EndCinematic : MonoBehaviour
{

    public Transform CinematicRoot;

    private PlayerController Player;
    private bool CinematicPlay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player = GameObject.Find("Player").GetComponent<PlayerController>();
            
            CinematicPlay = true;
            GameObject.Find("Cam").GetComponent<PlayerCam>().enabled = false;
            GameObject.Find("Cam").GetComponent<Animator>().SetInteger("EndScene", 2);
            GameObject.Find("KnightMesh").GetComponent<Animator>().SetTrigger("Ending");
            GameObject.Find("EndingDoubleDoor").GetComponent<Animator>().SetTrigger("Ending");
            GameObject.Find("PostProcessingMain").GetComponent<PostProcessVolume>().weight = 0;
            GameObject.Find("PostProcessingCine").GetComponent<PostProcessVolume>().weight = 1;
        }
    }

    private void Update()
    {
        if (CinematicPlay)
        {
            Player.gameObject.transform.position = CinematicRoot.position;
        }
    }
}
