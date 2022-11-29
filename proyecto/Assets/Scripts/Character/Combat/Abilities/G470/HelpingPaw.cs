using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingPaw : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "HELPING PAW";
        description = "G470 lends a paw to an ally, boosting defense for 3 turns";
    }
    public override void Effect(Character Figther)
    {
        DefBoost.CreateDefBoost(this.GetComponent<Character>().getDefense(), 3, Figther);
    }
    public override void BeforeTurn()
    {
        cooldown--;
    }
}
