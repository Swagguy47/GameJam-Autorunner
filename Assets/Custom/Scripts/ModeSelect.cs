using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    public void GamemodeSelect(int mode)
    {
        this.GetComponent<Animator>().SetInteger("Scene", mode);
    }

    public void LoadEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void LoadMedium()
    {
        SceneManager.LoadScene("Medium");
    }
    public void LoadHard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void LoadEndless()//Dunno if I have the time to add this
    {
        SceneManager.LoadScene("Endless");
    }
}
