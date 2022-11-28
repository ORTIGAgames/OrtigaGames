using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyShot : Abilities
{
    public void Awake()
    {
        cooldown = new CoolDown();
        Role = "Damage";
        Name = "LUCKY SHOT";
        description = "Norbert tries a risky strategy in combat, having a 50% chance to success, dealing a big amount of damage to an enemy if hit";
    }
    public override void Effect(Character Figther)
    {
        GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Norbert");
        int chanza = Random.Range(0, 11);
        print(chanza);
        if(chanza % 2 == 0)
            Figther.setHealth(Figther.getHealth() - 20);
    }
}
