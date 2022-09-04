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
        GlobalVariables.GameDifficulty = 0;
        SceneManager.LoadScene("Game");
    }
    public void LoadMedium()
    {
        GlobalVariables.GameDifficulty = 1;
        SceneManager.LoadScene("Game");
    }
    public void LoadHard()
    {
        GlobalVariables.GameDifficulty = 2;
        SceneManager.LoadScene("Game");
    }
    public void LoadEndless()//Dunno if I have the time to add this
    {
        GlobalVariables.GameDifficulty = 3;
        SceneManager.LoadScene("Game");
    }
}
