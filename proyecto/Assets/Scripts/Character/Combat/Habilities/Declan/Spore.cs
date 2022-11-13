using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "SPORE";
    }
    public override void Effect(Character Figther)
    {
        Figther.setTurn(Figther.getTurn() + 1);
    }
}
