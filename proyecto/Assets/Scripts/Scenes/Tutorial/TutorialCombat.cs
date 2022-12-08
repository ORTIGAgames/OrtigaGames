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

    string[] texts = {"To move your crewmates you have to click on them and then on an empty green hexagon",
    "To start a combat you have to click on a crewmate then, if the hexagon of an enemy is red, click on the enemy. The green hexagons will transform into blue, move your crewmate into one of this and click again on the enemy. To finish the attack you have to clik on one of the button that has appeared, the right one is the normal attack and the left one is the ability.",
    "Each crewmate has an unique ability, click on the arrow next to the ability icon in the stats menu and see what does. Remember the abilities could be to help other or to attack enemies."
    };

    int num = 0;

    public void Open()
    {
        menuTutorial.SetActive(true);
        menuTutorial.layer = -1;
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
