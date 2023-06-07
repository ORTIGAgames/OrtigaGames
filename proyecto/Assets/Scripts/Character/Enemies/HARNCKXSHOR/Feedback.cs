using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Image>().sprite == null)
            this.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
        else
            this.GetComponent<Image>().color = new Color(255, 255, 255, 255f);
    }
}
