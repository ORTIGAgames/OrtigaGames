using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TutorialMechanics : MonoBehaviour
{
    bool tutorialNow;
    bool first = false;
    bool second = false;
    bool three = false;
    bool four = false;
    bool five = true;
    bool six = false;
    bool seven = true;
    bool eight = false;

    int step = 0;
    string[] welcome = { 
        "First of all, find your crewmate on the map. If you click on the face of the botton left of the screen the camera will navigate directly to him.",
        "Then, you need to know how to move around the level, so click on Norbert, your ally, and see what happens.",
        "Each ally has a movement and an action on each of their turns, the green hexagons represent empty spaces where they can move to, yellow ones represent allies and the red ones are for enemies. On the botton right will always appear a cross to cancel the current action. Click on an empty space to move Declan.",
        "The turn doesn´t end until you click again on an empy space or do an action. When all the allies end their turn the enemy starts their turn and moves on their own, so you have to think in advantage of what they would do.",
        "You can see the movement and range of action of an enemy clicking on it, let´s try with the himenopio on the screen. When you are finish cancel and go back to Norbert.",
        "Now let's attack that enemy, click on Declan and then on the enemy, green hexagons will change into blue ones to show the range of attack of your unit. Click on one of the blue spaces.",
        "See on the top, the combat menu has the stats of the ally and the possible actions, attack and ability. You can see what does the abity clicking on the arrow next to the icon in the combat menu. ",
        "When one of your allies attack it will damage the enemy based on the enemies’ defense and your allies’ attack stat. Let's attack the enemy by clicking on them, and them on the right button that has appear",
        "Combat and strategy is not an easy task but that is why this is just a simulacrum of a real plausible scenery. The tutorial ends here, but find my button and I come back as you require. Now end this level and kill that enemy.",
        "If you need assistance just search for my icon"
    };

    public Canvas tutorial;
    public Text text;
    public SpriteRenderer icon;
    [SerializeField] Button[] buttons;
    public Scenery scene;
    public Character Declan;
    public Character Himenopio;
    public Manager game;
    public Button cont;

    // Start is called before the first frame update
    void Awake()
    {
        tutorialNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialNow == true)
        {
            
            tutorial.gameObject.SetActive(true);
            icon.gameObject.SetActive(false);
            if (step < 5)
            {
                foreach (Button b in buttons)
                {
                    b.interactable = false;
                }
            }
            
            
            foreach(Hexagon h in scene.board)
            {
                h.GetComponent<BoxCollider>().enabled = false;
            }

            
            text.text = welcome[step];
            
            if (step >= 1)
            {
                foreach (Hexagon h in scene.board)
                {
                    h.GetComponent<BoxCollider>().enabled = true;
                }
            }
            if (Declan.GetComponent<BoxCollider>().enabled == false && second == false)
            {
                step = 2;
                second = true;
            }
            
            if (Declan.getActualBlock() != Declan.getInitialBlock() && three==false)
            {
                step = 3;
                three = true;
            }

            if(game.allyturn == false && four == false)
            {
                step = 4;
                four = true;
                five = false;
                tutorial.sortingOrder = 0;
            }

            
            if (Declan.getActualBlock().getState() == Hexagon.CodeState.Action && six==false)
            {
                step = 6;
                six = true;
                seven = false;
            }

            if (Himenopio.getHealth() < Himenopio.MaxHealth && eight==false)
            {
                step = 8;
                eight = true;
                cont.gameObject.SetActive(true);
                tutorial.sortingOrder = 1;
            }
            if (step == 9)
                icon.gameObject.SetActive(true);
        }
        else
        {
            tutorial.gameObject.SetActive(false);
            cont.gameObject.SetActive(false);
            foreach (Button b in buttons)
            {
                b.interactable = true;
            }
            foreach (Hexagon h in scene.board)
            {
                h.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    public void face()
    {
        if (first == false)
        {
            step = 1;
            first = true;
            tutorial.sortingOrder=1;
        }
        if (five == false)
        {
            step = 5;
            five = true;
            foreach (Button b in buttons)
            {
                b.interactable = true;
            }
        }
    }

    public void arrow()
    {
        if (seven == false)
        {
            step = 7;
            seven = true;

        }
        

    }
    public void Click()
    {
        step++;
        if (step == 10)
        {
            tutorialNow = false;
        }
    }

    
}
