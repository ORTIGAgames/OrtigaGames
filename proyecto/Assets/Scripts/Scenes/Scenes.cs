using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;


    public void playMenu()
    {
        
        StartCoroutine(LoadMenu());
        Time.timeScale = 1f;
    }
    IEnumerator LoadMenu()
    {
        transition.SetTrigger("Start"); 
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(0);
    }
    public void playGame()
    {
        StartCoroutine(LoadGame());
        Time.timeScale = 1f;
    }
    IEnumerator LoadGame()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);
    }

    public void playLevel()
    {
        StartCoroutine(LoadLevel());
        Time.timeScale = 1f;
    }
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(2);
    }

    public void playCredits()
    {
        StartCoroutine(LoadCredits());
        Time.timeScale = 1f;
    }
    IEnumerator LoadCredits()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(3);
    }
    public void playLose()
    {
        StartCoroutine(LoadLose());
        Time.timeScale = 1f;
    }
    IEnumerator LoadLose()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(4);
    }
    public void playWin()
    {
        StartCoroutine(LoadWin());
        Time.timeScale = 1f;
    }
    IEnumerator LoadWin()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(5);
    }

    public void playTutorial()
    {
        StartCoroutine(LoadTutorial());
        Time.timeScale = 1f;
    }

    IEnumerator LoadTutorial()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(6);
    }
}
