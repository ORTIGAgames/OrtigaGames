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
        if(CoolDown == 0)
        {
            DefBoost.CreateDefBoost(this.GetComponent<Character>().getDefense(), 3, Figther);
            CoolDown += 2;
        }
    }
    public override void BeforeTurn()
    {
        CoolDown--;
    }
}
