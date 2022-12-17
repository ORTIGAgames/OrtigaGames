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
    public override void function()
    {
        float valueN;

        character.Move(character.getInitialBlock(), 0);

        foreach (Hexagon hex in character.game.stage.board)
        {
            if(hex.getState() == Hexagon.CodeState.WalkableE)
            {
                foreach (Character c in character.game.allies)
                {
                    if (c.getSide() != character.getSide())
                    {
                        int dx = c.getInitialBlock().dx - hex.dx;

                        int dy = c.getInitialBlock().dy - hex.dy;

                        if (Math.Sign(dx) == Math.Sign(dy)) valueN = (0.6f * c.getHealth()) + (0.4f * Math.Abs(dx + dy));

                        else valueN = c.getHealth() + Math.Max(Math.Abs(dx), Math.Abs(dy));

                        AddValue(hex, valueN);
                    }
                }
            }
        }

        Comparer comparer = new Comparer();
        valueHexagon.Sort(comparer);

        foreach (ValueHexagon V in valueHexagon)
        {
            if (!V.hexagon.getOccupant() && V.hexagon.getOccupant() != character)
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
                character.GetComponent<EnemyBehaviourState>().State = new AttackState(character);
                break;
            }
        }
        character.GetComponent<EnemyBehaviourState>().State = new WaitingState();
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


