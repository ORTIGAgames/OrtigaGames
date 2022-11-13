using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G470Attack : Attack
{
    public override int Action()
    {
        return this.GetComponent<Character>().getHealth() / 5;
    }
}
