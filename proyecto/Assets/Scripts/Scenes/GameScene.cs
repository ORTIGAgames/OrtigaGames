using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public List<Button> buttonToHide;
    public Text NameStats;
    public Text NameGlossary;
    public List<Button> buttonsStats;
    public List<Button> buttonsGlossary;
    public List<Button> buttonsLevels;
    public SpriteRenderer SpriteStas;
    public SpriteRenderer SpriteGlossary;
    public Canvas Stats;
    public Canvas Glossary;
    public Canvas Level;

    public void HideBaseGlossary()
    {
        foreach (Button b in buttonToHide)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button b in buttonsGlossary)
        {
            b.gameObject.SetActive(true);
        }

        NameGlossary.gameObject.SetActive(true);
        SpriteGlossary.gameObject.SetActive(true);
        Glossary.gameObject.SetActive(true);
    }

    public void HideBaseLevel()
    {
        foreach (Button b in buttonToHide)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button b in buttonsLevels)
        {
            b.gameObject.SetActive(true);
        }

        Level.gameObject.SetActive(true);
    }
    public void HideBaseStats()
    {
        foreach(Button b in buttonToHide)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button b in buttonsStats)
        {
            b.gameObject.SetActive(true);
        }
        NameStats.gameObject.SetActive(true);
        SpriteStas.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
    }
    public void Hide()
    {
        foreach (Button b in buttonToHide)
        {
            b.gameObject.SetActive(true);
        }
        foreach (Button b in buttonsStats)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button b in buttonsGlossary)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button b in buttonsLevels)
        {
            b.gameObject.SetActive(false);
        }
        NameStats.gameObject.SetActive(false);
        NameGlossary.gameObject.SetActive(false);
        SpriteStas.gameObject.SetActive(false);
        SpriteGlossary.gameObject.SetActive(false);
        Stats.gameObject.SetActive(false);
        Glossary.gameObject.SetActive(false);
        Level.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
