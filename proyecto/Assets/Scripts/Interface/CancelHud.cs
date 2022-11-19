using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelHud : MonoBehaviour
{
    public Button CancelB;
    public Character active;
    public Manager game;

    public void Awake()
    {
        CancelB = this.GetComponent<Button>();
    }

    public void Update()
    {
        if (CancelB.gameObject.activeSelf)
        {
            active = game.lastClicked;
            CancelB.onClick.AddListener(active.Cancel);
        }
    }
}
