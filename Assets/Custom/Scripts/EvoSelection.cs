using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvoSelection : MonoBehaviour
{
    public EvoCard EvoTemplate;
    public TMPro.TextMeshProUGUI BuffUI;
    public int Buff;
    public TMPro.TextMeshProUGUI NerfUI;
    public int Nerf;
    public TMPro.TextMeshProUGUI ItemUI;
    public int Item;

    public void RefreshUI()
    {
        BuffUI.text = EvoTemplate.Buffs[Buff];
        NerfUI.text = EvoTemplate.Nerfs[Nerf];
        ItemUI.text = EvoTemplate.Items[Item];
    }
}
