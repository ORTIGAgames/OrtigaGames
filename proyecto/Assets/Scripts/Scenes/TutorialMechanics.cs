using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TutorialMechanics : MonoBehaviour, IPointerClickHandler
{
    bool tutorialNow;
    bool first = false;
    bool second = false;
    bool three = false;
    bool four = false;
    bool five = false;
    int step = 0;
    string[] welcome = { 
        "First of all, you need to know how to move around the level, so click on Declan, your ally, and see what happens.",
        "Each ally has a movement and an action on each of their turns, the green hexagons represent empty spaces where they can move to, yellow ones represent allies and the red ones are for enemies. Click on an empty space to move Declan.",
        "When all the allies end their turn the enemy starts their turn and moves on their own, so you have to think in advantage of what they would do.",
        "Now let's attack that enemy, click on Declan and then on the enemy, green hexagons will change into blue ones to show the range of attack of your unit. Click on one of the blue spaces.",
        "See on the top, a combat menu appears, with the stats of the ally and the possible actions, attack and ability. When one of your allies attack it will damage the enemy based on the enemies’ defense and your allies’ attack stat. And the ability depends on each ally but don't get into it now. Let's attack the enemy for the moment.",
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
            foreach (Button b in buttons)
            {
                b.interactable = false;
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
            if (Declan.GetComponent<BoxCollider>().enabled == false && first == false)
            {
                step = 1;
                first = true;
            }
            
            if (Declan.getActualBlock() != Declan.getInitialBlock() && second==false)
            {
                step = 2;
                second = true;
            }

            if(game.allyturn==false && three == false)
            {
                step = 3;
                three = true;

            }
            
            if (step >= 3)
            {
                foreach (Button b in buttons)
                {
                    b.interactable = true;
                }
            }
            if (Declan.getActualBlock().getState() == Hexagon.CodeState.Action && four==false)
            {
                step = 4;
                four = true;
            }
            if (Himenopio.getHealth() < Himenopio.MaxHealth && five==false)
            {
                step = 5;
                five = true;
            }
            if (step == 6)
                icon.gameObject.SetActive(true);
        }
        else
        {
            tutorial.gameObject.SetActive(false);
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
    public void OnPointerClick(PointerEventData eventData)
    {
        if(step>=5)
            step++;
        if (step == 7)
        {
            tutorialNow = false;
        }
    }
}
