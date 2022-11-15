using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelHud : MonoBehaviour
{
    public Button CancelB;
    public Ally active;
    public Manager game;

    public void Awake()
    {
        CancelB = this.GetComponent<Button>();
    }

    public void Update()
    {
        if (CancelB.gameObject.active)
        {
            active = game.activeAlly;
            CancelB.onClick.AddListener(active.Cancel);
        }
    }
}