using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectScreen : MonoBehaviour
{
    public void Appear()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);
        this.GetComponent<Animator>().SetBool("Awake", true);
    }
    public void Disappear()
    {
        transform.localPosition = new Vector3(0, -1000, 0);
        transform.localScale = new Vector3(0, 0, 0);
    }

    public void FadeOut()
    {
        this.GetComponent<Animator>().SetBool("Awake", false);
    }
}
