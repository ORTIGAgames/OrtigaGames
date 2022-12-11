using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARNCKSOR : EnemyBehaviour
{
    public override Hexagon BestMove(Hexagon hex)
    {
        throw new System.NotImplementedException();
    }

    public override int DistanceHexagon(Hexagon goal)
    {
        throw new System.NotImplementedException();
    }

    public override void EnemyControl()
    {
        //Movement
        this.GetComponent<Enemy>().setActualBlock(this.GetComponent<Enemy>().getInitialBlock());
        this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
        //this.GetComponent<Enemy>().CharacterMove(this.GetComponent<Enemy>().getActualBlock(), false);

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
            Debug.Log("Attack " + weaker.getName());
            this.GetComponent<Enemy>().game.CombatActivation(this.GetComponent<Enemy>(), weaker);
            this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().game, "Action");
        }
        else
        {
            this.GetComponent<Enemy>().EndTurn();
        }
    }

    public override int ValueHexagon(Hexagon hex)
    {
        throw new System.NotImplementedException();
    }
}
