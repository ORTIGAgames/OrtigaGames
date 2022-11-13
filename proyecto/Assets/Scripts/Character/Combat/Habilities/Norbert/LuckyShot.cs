using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyShot : Abilities
{
    public void Awake()
    {
        Role = "Damage";
        Name = "LUCKY SHOT";
    }
    public override void Effect(Character Figther)
    {
        int chanza = Random.Range(0, 2);
        print(chanza);
        if(chanza == 1)
            Figther.setHealth(Figther.getHealth() - 20);
    }
}
