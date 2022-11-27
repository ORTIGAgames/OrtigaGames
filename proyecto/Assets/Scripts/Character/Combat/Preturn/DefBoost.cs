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
    }

    public static void CreateDefBoost(int b, int c, Character ch)
    {
        DefBoost myC = ch.gameObject.AddComponent<DefBoost>();
        myC.BoostPower = b;
        myC.counter = c;
        myC.Boosted = ch;
        myC.Boosted.setDefense(myC.Boosted.getDefense() + myC.BoostPower);
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
