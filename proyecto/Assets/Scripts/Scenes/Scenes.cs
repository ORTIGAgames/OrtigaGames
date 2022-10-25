using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void playMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void playLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void playCredits()
    {
        SceneManager.LoadScene(3);
    }
}
