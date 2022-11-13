using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingPaw : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "HELPING PAW";
    }
    public override void Effect(Character Figther)
    {
        DefBoost.CreateDefBoost(this.GetComponent<Character>().getDefense(), 3, Figther);
    }
}
