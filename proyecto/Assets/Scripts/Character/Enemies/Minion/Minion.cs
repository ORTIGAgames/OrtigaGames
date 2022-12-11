using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : EnemyBehaviour
{
    public override Hexagon BestMove(Hexagon hex)
    {
        List<Hexagon> movement = hex.neighbours;
        var value = -1000;
        Hexagon bestHexagon = hex;
        foreach (Hexagon a in movement)
        {
            if (a != null)
            {
                var tempValue = ValueHexagon(a);
                if (tempValue > value)
                {
                    value = tempValue;
                    bestHexagon = a;
                }
            }

        }
        return bestHexagon;
    }

    public override int ValueHexagon(Hexagon hex)
    {
        var value = -1000;
        foreach (Ally a in this.GetComponent<Enemy>().game.allies)
        {

            int tempvalue = (40 * 2 - a.getHealth()) - DistanceHexagon(a.getActualBlock());
            if (tempvalue > value)
                value = tempvalue;
        }
        return value;
    }

    public override int DistanceHexagon(Hexagon goal)
    {
        int dx = this.GetComponent<Enemy>().getActualBlock().dx - goal.dx;

        int dy = this.GetComponent<Enemy>().getActualBlock().dy - goal.dy;

        if (Math.Sign(dx) == Math.Sign(dy))
            return (Math.Abs(dx + dy));
        else
            return (Math.Max(Math.Abs(dx), Math.Abs(dy)));

        /*Vector3 goalPos = goal.transform.position;
        Vector3 currentPos = this.GetComponent<Enemy>().getActualBlock().transform.position;

        Vector3 distance = goalPos - currentPos;

        return (int)Mathf.Round(distance.magnitude);

        /*
        foreach(Hexagon a in goal.neighbours)
        {
            if (a == ActualBlock)
                return distance;
            else
                distance++;
                DistanceHexagon(a,distance);
        }
        return distance;*/
    }

    public override void EnemyControl()
    {
        //Movement
        this.GetComponent<Enemy>().setActualBlock(this.GetComponent<Enemy>().getInitialBlock());
        this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
        Hexagon movement = this.GetComponent<Enemy>().getActualBlock();
        for (int i = 0; i <= ((int)this.GetComponent<Enemy>().getMovement()); i++)
        {
            Hexagon aux = BestMove(movement);
            movement = aux;
        }

        if (!movement.getOccupant())
            this.GetComponent<Enemy>().CharacterMove(movement, false);
        else
        {
            foreach (Hexagon h in movement.neighbours)
            {
                if (h && !h.getOccupant())
                {
                    this.GetComponent<Enemy>().CharacterMove(h, false);
                    break;
                }

            }
        }

        //Combat 

        Character weaker = null;
        int weakerLife = 100;
        foreach (Hexagon hex in this.GetComponent<Enemy>().game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                if (hex.getOccupant().getHealth() < weakerLife)
                {
                    weakerLife = hex.getOccupant().getHealth();
                    weaker = hex.getOccupant();
                }
            }

        }
        if (weaker)
        {
            this.GetComponent<Enemy>().game.CombatActivation(this.GetComponent<Enemy>(), weaker);
            this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().game, "Action");
        }
        else
        {
            this.GetComponent<Enemy>().EndTurn();
        }
    }
}
