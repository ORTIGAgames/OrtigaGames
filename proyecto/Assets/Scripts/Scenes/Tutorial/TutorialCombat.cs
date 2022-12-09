using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCombat : MonoBehaviour
{
    [SerializeField] GameObject menuTutorial;
    public Text text;
    public Manager game;
    [SerializeField] Button[] buttons;

    string[] texts = {"To move your crewmates you have to click on them, click on an empty green hexagon, and then click again.",
    "To start a combat you have to click on a crewmate. If an enemy's hexagon is red, click on that enemy, after that, the hexagons from where that crewmate can attack the enemy will turn blue. Move your crewmate into one of these hexagons and click again on the enemy. To finish the attack you'll have to click on the rigth button for a regular attack, or on the left one for a special ability.",
    "Each crewmate has an unique ability, click on the arrow next to the ability icon in the stats menu to learn about it. Keep in mind that abilities could be used for attack or for support, so you migth need to click on an enemy or an ally to use it."
    };

    int num = 0;

    public void Open()
    {
        menuTutorial.SetActive(true);
        menuTutorial.layer = 5;
        game.CollisionDown();
        foreach (Button b in buttons)
        {
            b.enabled = false;
        }
    }
    public void Close()
    {
        menuTutorial.SetActive(false);
        game.CollisionUp();
        foreach (Button b in buttons)
        {
            b.enabled = true;
        }
    }

    public void select(int a)
    {
        num = a;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = texts[num];
    }
}
