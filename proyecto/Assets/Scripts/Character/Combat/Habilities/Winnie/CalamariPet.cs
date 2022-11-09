using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalamariPet : MonoBehaviour
{
    public Ally attached;
    public Manager game;

    public void Heal()
    {
        if (game.allyturn)
        {
            attached.setHealth(attached.getHealth() + 1);
        }
    }
}
