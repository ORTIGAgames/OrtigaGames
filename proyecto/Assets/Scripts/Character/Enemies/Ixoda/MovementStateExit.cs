using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateExit : State
{
    List<ValueHexagon> valueHexagon = new List<ValueHexagon>();
    Enemy character;

    public MovementStateExit(Enemy c)
    {
        character = c;
        function();
    }
    public override void function()
    {
        Debug.Log("movement State");
        float valueN;
        character.Move(character.getInitialBlock(), 0);

        foreach (Hexagon hex in character.game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.WalkableE)
            {
                float dx = (-7) - hex.dx;
                float dy = 4 - hex.dy;
                if (Math.Sign(dx) == Math.Sign(dy)) valueN = Math.Abs(dx + dy);
                else valueN = Math.Max(Math.Abs(dx), Math.Abs(dy));
                AddValue(hex, valueN);
            }
        }

        foreach (ValueHexagon V in valueHexagon)
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

        character.GetComponent<EnemyBehaviourState>().state = new WaitingState();
        character.EndTurn();
    }

    public void AddValue(Hexagon direction, float value)
    {
        ValueHexagon component = new ValueHexagon(direction, value);
        valueHexagon.Add(component);
    }
}

