using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnieAttack : Attack
{
    public override int Action()
    {
        return this.GetComponent<Character>().getDamage();
    }
}
