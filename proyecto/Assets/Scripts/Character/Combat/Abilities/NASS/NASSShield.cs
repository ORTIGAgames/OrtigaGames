using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NASSShield : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "NASS SHIELD";
        description = "NASS protects an ally, blocking all the damage it recieves";
    }
    public override void Effect(Character Figther)
    {
        GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Nass");
        DamageBlocker.CreateDamageBlocker(1, Figther.GetComponent<Character>(), this.GetComponent<Character>());
        cooldown += 6;
        GameObject.Find("Manager").GetComponent<Manager>().preTurn.Add(this);
    }

    public override void BeforeTurn()
    {
        if (cooldown > 0) cooldown--;
        else GameObject.Find("Manager").GetComponent<Manager>().preTurn.Remove(this);
    }
}
