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
            //efecto de bloqueado
            Boosted.setHealth(health);
            FeedBack indicator = Instantiate(Boosted.FeedbackResponse, transform.position, Quaternion.identity).GetComponent<FeedBack>();
            indicator.SetAction(-1, Booster.GetComponent<Abilities>().icon, 3.5f); ;
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
