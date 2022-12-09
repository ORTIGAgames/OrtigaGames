using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARNCKXSHORAttack : Attack
{
    public override int Action()
    {
        return this.GetComponent<Character>().getDamage();
    }
}
