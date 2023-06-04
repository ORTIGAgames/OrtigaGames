using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARNCKXSHORScream : Abilities
{
    public List<Enemy> minions;
    public override void Effect(Character Figther)
    {
        minions = GameObject.Find("Manager").GetComponent<ManagerHARNCKXSHOR>().minions;
        foreach (Enemy m in minions.ToArray())
        {
            m.GetComponent<Minion>().listen = true;
        }
        this.GetComponent<UtilitySystem>().scream=true;
    }
    public override void BeforeTurn()
    {
        if (cooldown > 0) cooldown--;
        else GameObject.Find("Manager").GetComponent<Manager>().preTurn.Remove(this);
    }
}
