using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARNCKXSHORHealing : Abilities
{
    public List<Enemy> minions;

    public override void Effect(Character Figther)
    {
        minions = GameObject.Find("Manager").GetComponent<ManagerHARNCKXSHOR>().minions;
        foreach(Enemy m in minions.ToArray())
        {
            this.GetComponent<Enemy>().setHealth(this.GetComponent<Enemy>().getHealth() + 5);
            this.GetComponent<Enemy>().game.DeleteCharacter(m);
        }
    }

    public override void BeforeTurn()
    {
        if (cooldown > 0) cooldown--;
        else GameObject.Find("Manager").GetComponent<Manager>().preTurn.Remove(this);
    }
}
