using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalamariPet : PreTurn
{
    public Ally attached;
    public Manager game;
    float timerCount;

    public void Start()
    {
        game.preTurn.Add(this);
    }
    public void Update()
    {
        timerCount += Time.deltaTime;

        this.transform.position = attached.transform.position + new Vector3(Mathf.Cos(timerCount)/15, .02f, Mathf.Sin(timerCount)/15);
    }
    public override void BeforeTurn()
    {
        print("hola" + attached.getHealth());
        attached.setHealth(attached.getHealth() + 1);
    }
}
