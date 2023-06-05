using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    List<ValueHexagon> valueHexagon = new List<ValueHexagon>();
    Enemy character;
    
    public MovementState(Enemy c)
    {
        character = c;
        function();
    }
    public MovementState(Enemy c, bool activated)
    {
        character = c;
        function2();
    }
    public void function2()
    {

    }
    public override void function()
    {
        Debug.Log("movement State");
        float valueN;
        character.Move(character.getInitialBlock(), 0);
        //El primero que llegue se lo lleva
        foreach (Hexagon hex in character.game.stage.board)
        {
            if(hex.getState() == Hexagon.CodeState.WalkableE)
            {
                foreach (Character c in character.game.allies)
                {
                    float dx = c.getInitialBlock().dx - hex.dx;
                    float dy = c.getInitialBlock().dy - hex.dy;
                    if (Math.Sign(dx) == Math.Sign(dy)) valueN = Math.Abs(dx + dy) * (1 / (float)c.getHealth());
                    else valueN = (Math.Max(Math.Abs(dx), Math.Abs(dy)) * (1 / (float)c.getHealth()));
                    AddValue(hex, valueN);
                }
            }
        }

        foreach(ValueHexagon V in valueHexagon)
        {
            Debug.Log(V.hexagon + " " + V.value + " pre value");
        }

        Comparer comparer = new Comparer();
        valueHexagon.Sort(comparer);

        foreach (ValueHexagon V in valueHexagon)
        {
            Debug.Log(V.hexagon + " " + V.value + " post value");
        }

        foreach (ValueHexagon V in valueHexagon)
        {
            if (!V.hexagon.getOccupant() || V.hexagon.getOccupant() == character)
            {
                character.CharacterMove(V.hexagon, false);
                break;
            }
        }

        character.getStyle().Action(character.getInitialBlock(), 0, character);

        foreach (Hexagon hex in character.game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                character.GetComponent<EnemyBehaviourState>().state = new AttackState(character);
                break;
            }
        }
        character.GetComponent<EnemyBehaviourState>().state = new WaitingState();
        character.EndTurn();
    }

    public void AddValue(Hexagon direction, float value)
    {
        ValueHexagon component = new ValueHexagon(direction, value);
        valueHexagon.Add(component);
    }
}
class ValueHexagon
{
    public Hexagon hexagon;
    public float value;

    public ValueHexagon(Hexagon h, float v)
    {
        hexagon = h;
        value = v;
    }
}
class Comparer : IComparer<ValueHexagon>
{
    public int Compare(ValueHexagon x, ValueHexagon y)
    {
        if (x.value < y.value) return -1;
        if (x.value > y.value) return 1;
        else return 0;       
    }
}


