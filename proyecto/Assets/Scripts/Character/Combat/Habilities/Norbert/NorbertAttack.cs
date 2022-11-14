using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorbertAttack : Attack
{
    public override int Action()
    {
        int dmg = 0;

        for (int i = 0; i < 2; i++)
        {
            dmg = dmg + Random.Range(2, this.GetComponent<Character>().getDamage());
        }

        return dmg;
    }
}
