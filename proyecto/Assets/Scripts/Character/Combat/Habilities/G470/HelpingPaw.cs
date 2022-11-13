using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingPaw : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "Helping Paw";
    }
    public override void Effect(Character Figther)
    {
        DefBoost.CreateDefBoost(this.GetComponent<Character>().getDefense(), 3, Figther);
    }
}
