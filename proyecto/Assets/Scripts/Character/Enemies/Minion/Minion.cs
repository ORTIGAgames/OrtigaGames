using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : EnemyBehaviour
{
    public bool listen = false;
    public Image feedback;
    public Sprite[] differentActions;
    public  Hexagon BestMoveBOSS(Hexagon hex)
    {
        List<Hexagon> movement = hex.neighbours;
        var value = -1000;
        Hexagon bestHexagon = hex;
        foreach (Hexagon a in movement)
        {
            if (a != null)
            {
                var tempValue = DistanceHexagon(GameObject.Find("Manager").GetComponent<ManagerHARNCKXSHOR>().stage.Block(0));
                
                if (tempValue > value)
                {
                    value = tempValue;
                    bestHexagon = a;
                }
            }

        }
        return bestHexagon;
    }
    public override Hexagon BestMove(Hexagon hex)
    {
        List<Hexagon> movement = hex.neighbours;
        var value = 1000;
        Hexagon bestHexagon = hex;
        foreach (Hexagon a in movement)
        {
            if (a != null)
            {
                var tempValue = ValueHexagon(a);
                if (tempValue < value)
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
        print("allies");
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
        int dx = this.GetComponent<Enemy>().getActualBlock().dx - goal.dx;

        int dy = this.GetComponent<Enemy>().getActualBlock().dy - goal.dy;

        if (Math.Sign(dx) == Math.Sign(dy))
            return (Math.Abs(dx + dy));
        else
            return (Math.Max(Math.Abs(dx), Math.Abs(dy)));

    }

    public override void EnemyControl()
    {
        if(listen == false)
        {
            game.stage.Reset();
            this.GetComponent<Enemy>().setActualBlock(this.GetComponent<Enemy>().getInitialBlock());
            this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
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
                print("hola");
                feedback.GetComponent<ShowFeedback>().ShowDecission(differentActions[1]);
                StartCoroutine(DecissionMake(1, weaker));
                StartCoroutine(Wait());
            }
            else
            {
                //Movement
                feedback.GetComponent<ShowFeedback>().ShowDecission(differentActions[0]);
                StartCoroutine(DecissionMake(0, null));
                StartCoroutine(Wait());

            }          
        }
        else
        {
            feedback.GetComponent<ShowFeedback>().ShowDecission(differentActions[2]);
            StartCoroutine(DecissionMake(2, null));
            StartCoroutine(Wait());
        }
    }

    IEnumerator DecissionMake(int e, Character c)
    {
        yield return new WaitForSeconds(2f);
        switch (e)
        {
            case 0:
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
                break;
            case 1:
                this.GetComponent<Enemy>().game.CombatActivation(this.GetComponent<Enemy>(), c);
                this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().game, "Action");
                break;
            case 2:
                this.GetComponent<Enemy>().setActualBlock(this.GetComponent<Enemy>().getInitialBlock());
                this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
                Hexagon movement1 = this.GetComponent<Enemy>().getActualBlock();
                for (int i = 0; i <= ((int)this.GetComponent<Enemy>().getMovement() + 1) * 2; i++)
                {
                    Hexagon aux = BestMoveBOSS(movement1);
                    movement = aux;
                }

                if (!movement1.getOccupant())
                    this.GetComponent<Enemy>().CharacterMove(movement1, false);
                else
                {
                    foreach (Hexagon h in movement1.neighbours)
                    {
                        if (h && !h.getOccupant())
                        {
                            this.GetComponent<Enemy>().CharacterMove(h, false);
                            break;
                        }

                    }
                }
                listen = false;
                break;
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        this.feedback.GetComponent<ShowFeedback>().Unshow();
        this.GetComponent<Enemy>().EndTurn();
    }
}
