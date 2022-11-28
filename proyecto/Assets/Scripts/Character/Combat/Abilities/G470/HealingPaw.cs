using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPaw : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "HEALING PAW";
        description = "G470 rubs against an ally, healing that ally the same amount as 1/5 of G470'S life";
    }
    public override void Effect(Character Figther)
    {
        GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Gato");
        Figther.setHealth(Figther.getHealth() + this.GetComponent<Character>().getHealth() * 1 / 5);
    }
}