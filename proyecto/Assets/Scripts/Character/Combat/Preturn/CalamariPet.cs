using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalamariPet : PreTurn
{
    public Ally attached;
    public Manager game;
    float timerCount;

    public void Awake()
    {
        game.preTurn.Add(this);
    }
    public void Update()
    {
        timerCount += Time.deltaTime;
        if (this.attached) this.transform.position = attached.transform.position + new Vector3(Mathf.Cos(timerCount) / 15, .02f, Mathf.Sin(timerCount) / 15);
    }
    public override void BeforeTurn()
    {
        attached.setHealth(attached.getHealth() + 2);
    }
}
