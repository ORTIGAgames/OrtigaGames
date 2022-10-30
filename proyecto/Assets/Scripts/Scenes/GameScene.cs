using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public List<Button> buttonToHide;
    public Text Name;
    public List<Button> Back;
    public SpriteRenderer Sprite;
    public Canvas Stats;

    // Start is called before the first frame update
    void Start()
    {

       
    }

    public void HideBase()
    {
        foreach(Button b in buttonToHide)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button b in Back)
        {
            b.gameObject.SetActive(true);
        }
        Name.gameObject.SetActive(true);
        Sprite.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
    }
    public void HideStats()
    {
        foreach (Button b in buttonToHide)
        {
            b.gameObject.SetActive(true);
        }
        foreach (Button b in Back)
        {
            b.gameObject.SetActive(false);
        }
        Name.gameObject.SetActive(false);
        Sprite.gameObject.SetActive(false);
        Stats.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
