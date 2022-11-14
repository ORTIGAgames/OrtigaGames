using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPaw : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "HEALING PAW";
        description = "G470 rubs against an ally, healing a percentage of G470'S life";
    }
    public override void Effect(Character Figther)
    {
        Figther.setHealth(Figther.getHealth() + this.GetComponent<Character>().getHealth() * 1 / 5);
    }
}