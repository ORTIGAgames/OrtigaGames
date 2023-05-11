using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFeedback : MonoBehaviour
{
    public Image show;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        show.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDecission(Sprite decission)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Function(decission));
    }

    public void Unshow()
    {
        show.sprite = null;
        this.gameObject.SetActive(false);
    }

    IEnumerator Function(Sprite d)
    {
        yield return new WaitForSeconds(1.5f);
        print(this.gameObject.active);
        print(show.sprite);
        show.sprite = d;
    }
}
