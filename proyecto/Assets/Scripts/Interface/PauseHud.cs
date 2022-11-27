using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHud : MonoBehaviour
{
    [SerializeField] GameObject butonPause;
    [SerializeField] GameObject menuPause;
    public Manager game;
    public Canvas settings;
    public List<Hexagon> board;
    public List<Character> characters;
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

    public void ControlSettings()
    {
        settings.gameObject.SetActive(true);
    }
    public void HideSettings()
    {
        settings.gameObject.SetActive(false);
    }


}
