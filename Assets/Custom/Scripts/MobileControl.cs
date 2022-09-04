using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MobileControl : MonoBehaviour
{
    [HideInInspector]
    public bool Attack;
    [HideInInspector]
    public bool Jump;
    [HideInInspector]
    public bool Ability;

    //[SerializeField]
    //private Button JumpButton;
    //[SerializeField]
    //private Button AttackButton;
    //[SerializeField]
    //private Button AbilityButton;

    [SerializeField]
    private GameObject ConfirmMenu;

    public void ConfirmExit()
    {
        Time.timeScale = 0.001f;
        ConfirmMenu.SetActive(true);
    }

    public void ResetTimescale()
    {
        Time.timeScale = 1f;
        ConfirmMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void JumpDown()
    {
        Jump = true;
    }
    public void JumpUp()
    {
        Jump = false;
    }
    public void AttackDown()
    {
        Attack = true;
    }
    public void AttackUp()
    {
        Attack = false;
    }
    public void AbilityDown()
    {
        Ability = true;
    }
    public void AbilityUp()
    {
        Ability = false;
    }
}
