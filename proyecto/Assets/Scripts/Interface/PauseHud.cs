using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseHud : MonoBehaviour
{
    [SerializeField] Button[] butonPause;
    [SerializeField] GameObject menuPause;
    public Manager game;
    public Canvas settings;

    public void Pause()
    {
        Time.timeScale = 0f;
        foreach(Button b in butonPause)
        {
            b.enabled = false;
        }
        menuPause.SetActive(true);
        game.CollisionDown();
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        foreach (Button b in butonPause)
        {
            b.enabled = true;
        }
        menuPause.SetActive(false);
        game.CollisionUp();
    }

    public void ControlSettings()
    {
        settings.gameObject.SetActive(true);
    }
    public void HideSettings()
    {
        settings.gameObject.SetActive(false);
    }


}
