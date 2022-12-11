using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    [SerializeField] Button[] retries;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Button b in retries)
        {
            b.gameObject.SetActive(false);
        }
        retries[BetweenScenesControler.levelRetry].gameObject.SetActive(true);
    }

    
}
