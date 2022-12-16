using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    List<ValueHexagon> valueHexagon;
    public override void function()
    {

        Hexagon directionN = new Hexagon();
        float auxN = 9999;
        float valueN;
        List<Hexagon> betters = new List<Hexagon>();
        List<float> bettersValue = new List<float>();
        
        foreach (Hexagon h in this.GetComponent<Character>().getInitialBlock().neighbours)
        {
            foreach (Character c in this.GetComponent<Character>().game.players)
            {
                if (c.getSide() != this.GetComponent<Character>().getSide())
                {
                    int dx = c.getInitialBlock().dx - this.GetComponent<Character>().getActualBlock().dx;

                    int dy = c.getInitialBlock().dy - this.GetComponent<Character>().getActualBlock().dy;

                    if (Math.Sign(dx) == Math.Sign(dy)) valueN = (0.6f * c.getHealth()) + (0.4f * Math.Abs(dx + dy));

                    else valueN = c.getHealth() + Math.Max(Math.Abs(dx), Math.Abs(dy));

                    if (valueN < auxN)
                    {
                        auxN = valueN;
                        directionN = c.getInitialBlock();
                    }
                }
            }
            AddValue(directionN, auxN);
        }

        valueHexagon.Sort();

        foreach(ValueHexagon V in valueHexagon)
        {
            if (!V.hexagon.getOccupant())
            {
                this.GetComponent<Character>().CharacterMove(V.hexagon, false);
                break;
            }
        }

        this.GetComponent<Character>().getStyle().Action(this.GetComponent<Character>().getInitialBlock(), 0, this.GetComponent<Character>());

        foreach (Hexagon hex in this.GetComponent<Enemy>().game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                this.GetComponent<EnemyBehaviour>().State = new AttackState();
            }
        }

        this.GetComponent<EnemyBehaviour>().State = new WaitingState();
    }

    public void AddValue(Hexagon direction, float value)
    {
        ValueHexagon component = new ValueHexagon(direction, value);
        valueHexagon.Add(component);
    }
}
public class ValueHexagon
{
    public Hexagon hexagon;
    public float value;

    public ValueHexagon(Hexagon h, float v)
    {
        hexagon = h;
        value = v;
    }
}


