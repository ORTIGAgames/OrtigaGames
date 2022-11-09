using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalamariPet : MonoBehaviour
{
    public Ally attached;
    public Manager game;
    public int counts;

    public void Update()
    {
        this.transform.position = attached.transform.position + new Vector3(-.05f, .02f, 0);
        if (game.allyturn && counts < 0)
        {
            Heal();
            counts++;
        }
        if (!game.allyturn && counts > 0)
        {
            counts--;
        }
            
    }
    public void Heal()
    {
            attached.setHealth(attached.getHealth() + 1);
    }
}
