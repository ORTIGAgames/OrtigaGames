using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrangleAttack : Attack
{
    public override int Action()
    {

        float value;

        float healtV = (float)(this.GetComponent<Character>().getHealth() - 0) / (this.GetComponent<Character>().MaxHealth - 0);

        float DefenseV;

        if (this.GetComponent<DmgStyle>().defender.GetComponent<Character>().getDefense() < 5) DefenseV = 1;
        else DefenseV = 0;

        value = healtV * DefenseV;

        if (value > .5)
        {
            return (int)((this.GetComponent<Character>().getDamage() / .75 - this.GetComponent<Enemy>().game.defender.GetComponent<Character>().getDefense()) * 2);
        }
        else
        {
            return this.GetComponent<Character>().getDamage();
        }
    }
}
