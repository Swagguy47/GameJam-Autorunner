using UnityEngine;
using UnityEngine.UI;

public class SpriteLoop : MonoBehaviour
{
    public Sprite[] Sprites;
    [Range( 0.01f, 0.25f)]
    public float speed = 0.075f;


    private float delay;
    private int CurrentSprite = 0;

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0f)
        {
            CurrentSprite += 1;
            if (CurrentSprite != Sprites.Length)
            {
                this.GetComponent<Image>().sprite = Sprites[CurrentSprite];
            }
            else
            {
                CurrentSprite = 0;
                this.GetComponent<Image>().sprite = Sprites[CurrentSprite];
            }
                
            delay = speed;
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }
}
//speed is god awful, smaller numbers faster, bigger numbers slower. Use VERRRYYY small decimals