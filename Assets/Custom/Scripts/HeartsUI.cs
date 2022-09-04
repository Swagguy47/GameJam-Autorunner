using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    public PlayerController Player;
    public Transform HeartUI;
    public Transform ParentPosition;
    
    // God of all jank
    void Update()
    {
        transform.localPosition = new Vector3(Player.Health * -45, -500, 0);
        //transform.position = ParentPosition.position;
        HeartUI.position = ParentPosition.position;
        //HeartUI.position = new Vector3(960, 50, 0);
        HeartUI.localScale = new Vector3(Player.Health * 0.3f, 1, 1);
        HeartUI.GetComponent<RawImage>().uvRect = new Rect(0, 0,Player.Health, 1);
        HeartUI.transform.Find("Hearts").GetComponent<RawImage>().uvRect = new Rect(0, 0, Player.Health, 1);
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(Player.Health * 30, 100);
    }
}
