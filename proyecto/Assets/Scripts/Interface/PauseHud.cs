using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHud : MonoBehaviour
{
    [SerializeField] GameObject butonPause;
    [SerializeField] GameObject menuPause;
    public Manager game;
    public void Pause()
    {
        Time.timeScale = 0f;
        butonPause.SetActive(false);
        menuPause.SetActive(true);
        game.CollisionDown();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        butonPause.SetActive(true);
        menuPause.SetActive(false);
        game.CollisionUp();
    }
}
