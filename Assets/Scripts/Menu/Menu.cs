using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(string levelLable)
    {
        SceneManager.LoadScene(levelLable);
    }

    public void About(Animator animator)
    {
        animator.SetBool("IsOpen", !animator.GetBool("IsOpen"));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
