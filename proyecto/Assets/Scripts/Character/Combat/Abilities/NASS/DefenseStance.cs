using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseStance : Abilities
{
    public void Awake()
    {
        Role = "SelfSupport";
        Name = "DEFENSE STANCE";
        description = "NASS hugs himself tightly, boosting his defense and protecting himself for some turns";
    }
    public override void Effect(Character Figther)
    {
        DefBoost.CreateDefBoost(this.GetComponent<Character>().getDefense(), 3, this.GetComponent<Character>());
    }
}
