using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Character
{
    
    public override void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterMove(Hexagon h, bool c)
    {
        throw new System.NotImplementedException();
    }

    public override void EndTurn()
    {
        turn--;
    }

    public override void Move(Hexagon t, int i)
    {
        throw new System.NotImplementedException();
    }

    public override void OnMouseDown()
    {
        throw new System.NotImplementedException();
    }

    public override void ShowMove(Hexagon h)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        base.Awake();
        side = "Enemy";

        MaxHealth = 40;
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 20)
        {
           this.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
