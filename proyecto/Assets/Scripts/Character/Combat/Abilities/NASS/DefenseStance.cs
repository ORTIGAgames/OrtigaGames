using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseStance : Abilities
{
    public void Awake()
    {
        Role = "SelfSupport";
        Name = "DEFENSE STANCE";
        description = "NASS hugs himself tightly, boosting his defense and protecting himself for one turns";
    }
    public override void Effect(Character Figther)
    {
        GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Nass");
        DefBoost.CreateDefBoost(5, 1, this.GetComponent<Character>());
    }
}
