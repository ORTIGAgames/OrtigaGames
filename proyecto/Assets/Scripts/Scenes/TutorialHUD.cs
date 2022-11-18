using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialHUD : MonoBehaviour,IPointerClickHandler
{
    bool firstTime;
    int step = 0;
    string[] welcome = { "Welcome to the strategy exam to become an official galaxy captain",
        "If you are an expert Space Captain press skip if not please press continue.",
        "This exam consists of four virtual missions, each of them has a different objective and you should complete them correctly to pass.",
        "You will be controlling units based on your actual crew with their same abilities and physical appearance.",
        "Remember that you must avoid getting your crew killed, if at least one of them dies you will fail the mission and should restart it.",
        "If you have any questions about something, select my icon [imagen del icono] and I will help you.",
        "Would you like to review the battle mechanics?",
        "If you need assistant just search for my icon",
    };

    public Canvas tutorial;
    public Text text;
    [SerializeField] Button[] buttons;
    public Button skip;
    public Button cont;
    public Button play;
    public SpriteRenderer icon;


    // Start is called before the first frame update
    void Awake()
    {
        firstTime = BetweenScenesControler.firstTime;
        if (firstTime == true)
        {
            tutorial.gameObject.SetActive(true);
            foreach( Button b in buttons)
            {
                b.interactable = false;
            }
        }
        
    }

    private void OnDestroy()
    {
        BetweenScenesControler.firstTime = firstTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstTime == true)
        {
            skip.gameObject.SetActive(false);
            cont.gameObject.SetActive(false);
            play.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            text.text = welcome[step];
            if (step == 1)
            {
                skip.gameObject.SetActive(true);
                cont.gameObject.SetActive(true);
                
            }
            if (step == 6)
            {
                skip.gameObject.SetActive(true);
                play.gameObject.SetActive(true);
            }
            if (step == 7)
            {
                icon.gameObject.SetActive(true);
                
            }
                
        }
        else
        {
            tutorial.gameObject.SetActive(false);
            foreach (Button b in buttons)
            {
                b.interactable = true;
            }
        }
        
        
    }
    public void Skip()
    {
        
        step = 7;
    }
    public void Continue()
    {
        if (step >= 6)
        
            Skip();
        else
            step++;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (step == 1 || step == 6)
        {
            return;
        }
        step++;
        if (step == 8)
        {
            firstTime = false;
        }
    }

   
}

