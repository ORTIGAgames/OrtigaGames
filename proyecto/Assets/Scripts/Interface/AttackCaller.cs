using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    public Manager game;
    public string differentiator;
    public void Caller()
    { 
        game.attacker.getStyle().Action(game, differentiator);
    }
}
