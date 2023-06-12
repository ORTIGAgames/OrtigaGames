using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HimenopioAttack : Attack
{
    public ShowFeedback s;
    public override int Action()
    {
        return this.GetComponent<Character>().getDamage();
    }
}
