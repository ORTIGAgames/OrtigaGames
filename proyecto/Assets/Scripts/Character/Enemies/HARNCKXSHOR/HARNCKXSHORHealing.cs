using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARNCKXSHORHealing : Abilities
{
    public List<Enemy> minions = new List<Enemy>();

    public override void Effect(Character Figther)
    {
        foreach(Enemy m in minions)
        {
            this.GetComponent<Enemy>().setHealth(this.GetComponent<Enemy>().getHealth() + 5);
            this.GetComponent<Enemy>().game.DeleteCharacter(m);
        }
    }

    public override void BeforeTurn()
    {
        cooldown--;
    }
}
