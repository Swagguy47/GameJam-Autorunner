using UnityEngine;
using UnityEngine.UI;

public class BGScroll : MonoBehaviour
{
    public float SpeedMult = 1f;
    
    private Material ThisMat;
    private Transform Cam;
    private void Start()
    {
        Cam = GameObject.Find("Cam").transform;
        ThisMat = GetComponent<MeshRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Cam.position.x, Cam.position.y, transform.position.z);
        ThisMat.mainTextureOffset = new Vector2(Cam.position.x * SpeedMult, Cam.position.y * SpeedMult);
    }
}
