using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "SPORE";
        description = "Declan, shakes his spores out of his body boosting an ally and giving him an extra turn";
    }
    public override void Effect(Character Figther)
    {
        Figther.setTurn(Figther.getTurn() + 1);
    }
}
