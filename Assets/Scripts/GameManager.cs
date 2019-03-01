﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator fadeAnimator;

    private string levelToChange = "";

    public void LoadLevel(string level)
    {
        levelToChange = level;
        fadeAnimator.SetTrigger("Fade Out");
        Invoke("ChangeLevel", fadeAnimator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(levelToChange);
    }
}
