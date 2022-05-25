using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialObjectives : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Objective1;
    public TMPro.TextMeshProUGUI Objective2;
    public TMPro.TextMeshProUGUI Objective3;
    public Button ContinueButton;

    private bool O1; //press f
    private bool O2; //press lmb
    private bool O3; //Press space
    private bool O4; //Press shift

    void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.F))
        {
            O1 = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            O2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            O3 = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            O4 = true;
        }
    }

    private void UpdateUI()
    {
        if (O1 && !O2)
        {
            Objective1.text = "<color=grey>LMB/</color><color=green>F</color> - <color=grey>Attack</color>";
        }
        else if (!O1 && O2)
        {
            Objective1.text = "<color=green>LMB</color><color=grey>/F</color> - <color=grey>Attack</color>";
        }
        else if (!O1 && !O2)
        {
            Objective1.text = "<color=grey>LMB/F - Attack</color>";
        }
        else if (O1 && O2)
        {
            Objective1.text = "<color=green>LMB/F - Attack</color>";
        }

        if (O3)
        {
            Objective2.text = "<color=green>SPACEBAR - Jump</color>";
        }
        else
        {
            Objective2.text = "<color=grey>SPACEBAR - Jump</color>";
        }

        if (O4)
        {
            Objective3.text = "<color=green>Shift - Ability</color>";
        }
        else
        {
            Objective3.text = "<color=grey>Shift - Ability</color>";
        }

        if (O1 && O2 && O3 && O4)
        {
            ContinueButton.interactable = true;
        }
    }
}
