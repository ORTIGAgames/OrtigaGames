using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefBoost : PreTurn
{
    public Character Boosted;
    public int BoostPower, counter;
    Manager game;

    public void Awake()
    {
        game = GameObject.Find("Manager").GetComponent<Manager>();
        game.preTurn.Add(this);
        Boosted.setDefense(Boosted.getDefense() + BoostPower);
    }

    public static DefBoost CreateDefBoost(int b, int c, Character ch)
    {
        DefBoost myC = ch.gameObject.AddComponent<DefBoost>();
        myC.BoostPower = b;
        myC.counter = c;
        myC.Boosted = ch;
        return myC;
    }

    public override void BeforeTurn()
    {
        if(counter > 0)
        {
            counter--;
        }
        else
        {
            Boosted.setDefense(Boosted.getDefense() - BoostPower);
            game.preTurn.Remove(this);
            Destroy(this);
        }
    }

}
