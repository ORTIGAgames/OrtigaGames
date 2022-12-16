using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviourState: EnemyBehaviour
{
    private enum TStates { WAITING,MOVEMENT, ATTACK };
    private TStates actual = TStates.WAITING;

    public State State = new WaitingState();

    private void CreateStateMachine()
    {
       switch (actual)
       {
            case TStates.WAITING:
                if (this.GetComponent<Enemy>().getTurn() == 1)
                {
                    actual = TStates.MOVEMENT;
                }
                break;
            case TStates.MOVEMENT:
                movement();
                if (this.GetComponent<Enemy>().getInitialBlock()!= this.GetComponent<Enemy>().getActualBlock())
                {
                    actual = TStates.ATTACK;
                }
                break;
            case TStates.ATTACK:
                attack();
                if (this.GetComponent<Enemy>().getTurn() == 0)
                {
                    actual = TStates.WAITING;
                }
                break;
            default:
                Debug.LogError("Error");
                break;
        }
    }
    public void movement()
    {
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
    }
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
        var value = 1000;
        foreach (Ally a in this.GetComponent<Enemy>().game.allies)
        {

            int tempvalue = (40 * 2 - a.getHealth()) - DistanceHexagon(a.getActualBlock());
            if (tempvalue < value)
                value = tempvalue;
        }
        return value;
    }

    public override int DistanceHexagon(Hexagon goal) 
    {
        int dx = goal.dx - this.GetComponent<Enemy>().getActualBlock().dx;

        int dy = goal.dy - this.GetComponent<Enemy>().getActualBlock().dy;

        if (Math.Sign(dx) == Math.Sign(dy))
            return (Math.Abs(dx + dy));
        else
            return (Math.Max(Math.Abs(dx), Math.Abs(dy)));
    }
    public int DistanceHexagon(Hexagon goal, Hexagon start)
    {
        int dx = goal.dx - start.dx;

        int dy = goal.dy - start.dy;

        if (Math.Sign(dx) == Math.Sign(dy))
            return (Math.Abs(dx + dy));
        else
            return (Math.Max(Math.Abs(dx), Math.Abs(dy)));
    }

    public void attack()
    {
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
        this.GetComponent<Enemy>().EndTurn();
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
            this.GetComponent<Enemy>().EndTurn();
    }

    public Character combat(Hexagon actual, int enemyDistance, int iteration, int range)
    {
        Character weaker = null;
        int weakerLife = 100;
        

        if(iteration<range)
        {
            foreach (Hexagon hex in actual.neighbours)
            {
                if (hex != null && hex.getState() == Hexagon.CodeState.EnemyT)
                {
                    if (hex.getOccupant().getHealth() < weakerLife)
                    {
                        weakerLife = hex.getOccupant().getHealth();
                        weaker = hex.getOccupant();

                    }
                }
                else
                {
                    foreach (Ally a in this.GetComponent<Enemy>().game.allies)
                    {
                        if (hex!=null && DistanceHexagon(a.getActualBlock(), hex) < enemyDistance)
                        {
                            enemyDistance = DistanceHexagon(a.getActualBlock(), hex);
                            combat(a.getActualBlock(),enemyDistance,iteration+1,range);
                        }
                            
                    }

                }

            }
        }
        return weaker;
    }
}
