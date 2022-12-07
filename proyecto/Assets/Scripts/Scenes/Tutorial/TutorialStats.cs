using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialStats : MonoBehaviour
{
    
    bool firstStats;
    int step = 0;
    string[] welcome = { "This is where you update your allies to make them stronger",
        "If you are an expert Space Captain press skip if not please press continue.",
        "When you complete successfully a level you will get a limited number of points which can be used to update the stats of each ally",
        "You will have to decide which stats of which allies you will improve.",
        "A tip just for you! I recommend seeing what will be the next level objective to boost the stats that will help you pass it easier.",
        "To see a level objective and enemies you just have to select that level, just remember to go back to update your allies stats after you read it!",
        "If you need assistance just search for my icon",
    };
    public Canvas tutorial;
    public Text text;
    [SerializeField] Button[] buttons;
    public Button skip;
    public Button cont;
    public SpriteRenderer icon;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(step);
        firstStats = BetweenScenesControler.firstStats;
        
    }

    private void OnDestroy()
    {
        BetweenScenesControler.firstStats = firstStats;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (step == 7)
        {
            firstStats = false;
        }
        if (firstStats == true)
        {
            
            tutorial.gameObject.SetActive(true);
            foreach (Button b in buttons)
            {
                b.interactable = false;
            }
            skip.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            cont.gameObject.SetActive(true);
            text.text = welcome[step];
            if (step == 1)
            {
                skip.gameObject.SetActive(true);
                cont.gameObject.SetActive(true);

            }
            if (step == 6)
            {
                icon.gameObject.SetActive(true);
            }
            
        }
        else
        {
            tutorial.gameObject.SetActive(false);
            skip.gameObject.SetActive(false);
            cont.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            foreach (Button b in buttons)
            {
                b.interactable = true;
            }
        }
    }

    public void Skip()
    {
        step = 6;
    }
    public void Continue()
    {
        step++;
    }
    
    public void Help()
    {
        firstStats = true;
        step = 0;
    }
}
