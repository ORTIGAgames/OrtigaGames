using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackActivation : MonoBehaviour
{
    public Manager game;
    public string differentiator;
    public void Caller()
    {
        game.attacker.getStyle().Action(game, differentiator);
    }
}
