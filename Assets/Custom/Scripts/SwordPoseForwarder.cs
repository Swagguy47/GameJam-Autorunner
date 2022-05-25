using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPoseForwarder : MonoBehaviour
{
    public Sword ForwardedSword;
    public void ChangeSwordPose(int NewPose)
    {
        ForwardedSword.PoseChange(NewPose);
    }
    public void SwordHide()
    {
        ForwardedSword.Hide(false);
        ForwardedSword.gameObject.SetActive(false);
    }
}
