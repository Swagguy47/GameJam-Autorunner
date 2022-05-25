using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform Target;
    public bool Tracking = true;
    public bool TrackRotation = true;
    public bool UsePoses = true;
    public int Pose;
    public List<SwordPose> Poses;

    private bool Hidden;

    private float PoseX;
    private float PoseY;
    private float PoseZ;
    private float PoseW;

    private void Awake()//Initialize Pose
    {
        if (UsePoses)
        {
            PoseX = Poses[Pose].RotX;
            PoseY = Poses[Pose].RotY;
            PoseZ = Poses[Pose].RotZ;
            PoseW = Poses[Pose].RotW;
        }
    }

    void Update()
    {
        if (!Hidden)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            transform.localScale = new Vector3(0,0,0);
        }
        
        if (Tracking)
        {
            transform.position = Target.position;
        }
        if (TrackRotation)
        {
            if (UsePoses)
            {
                transform.rotation = Target.rotation * new Quaternion(PoseX, PoseY, PoseZ, PoseW);
            }
            else
            {
                transform.rotation = Target.rotation;
            }
        }
    }

    public void PoseChange(int NewPose) //Used in animations
    {
        Pose = NewPose;
        PoseX = Poses[Pose].RotX;
        PoseY = Poses[Pose].RotY;
        PoseZ = Poses[Pose].RotZ;
        PoseW = Poses[Pose].RotW;
    }

    public void Hide(bool newHide)
    {
        Hidden = newHide;
    }
}
