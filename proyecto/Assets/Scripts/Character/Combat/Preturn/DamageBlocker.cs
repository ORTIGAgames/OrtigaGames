using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlocker : PreTurn
{
    private Character Boosted, Booster;
    private int counter, health;
    Manager game;

    public void Update()
    {
        if (Boosted.getHealth() < health)
        {
            print(health - Boosted.getHealth());
            int damage = ((health - Boosted.getHealth()) <= Booster.getDefense()) ? 1 : (health - Boosted.getHealth()) - Booster.getDefense();
            print(damage);
            Boosted.setHealth(health);
            Booster.setHealth(Booster.getHealth() - damage);
        }
    }
    public void Awake()
    {
        game = GameObject.Find("Manager").GetComponent<Manager>();
        game.preTurn.Add(this);
    }

    public static void CreateDamageBlocker(int c, Character ch, Character ch2)
    {
        DamageBlocker myD = ch.gameObject.AddComponent<DamageBlocker>();
        myD.counter = c;
        myD.Boosted = ch;
        myD.Booster = ch2;
        myD.health = ch.getHealth();
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
}
