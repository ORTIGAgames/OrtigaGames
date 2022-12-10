using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text text;
    public SpriteRenderer image;
    // Start is called before the first frame update
    void Awake()
    {
        BetweenScenesControler.upgradePoint = 10;
        BetweenScenesControler.levelsCompleted++;
        Debug.Log(BetweenScenesControler.levelsCompleted);
        if (BetweenScenesControler.levelsCompleted >= 4)
        {
            text.gameObject.active = false;
            image.gameObject.active = true;
        }
    }

    
}
