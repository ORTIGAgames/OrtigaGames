using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : PreTurn
{
    public int counter;
    Manager game;
    public CoolDown()
    {
        game = GameObject.Find("Manager").GetComponent<Manager>();
        counter = 0;
    }
    public override void BeforeTurn()
    {
        if (counter > 0)
        {
            counter--;
        }
        else
        {
            game.preTurn.Remove(this);
            Destroy(this);
        }
    }
    public void PlusCounter(int i)
    {
        print(game);
        counter = i;
        game.preTurn.Add(this);
    }
}
