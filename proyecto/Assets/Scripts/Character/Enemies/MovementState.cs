using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    List<ValueHexagon> valueHexagon = new List<ValueHexagon>();
    List<HealingTree> arbolesC = new();
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
    public MovementState(Enemy c, List<HealingTree> arboles)
    {
        arbolesC = arboles;
        character = c;
        function3();
    }
    public void function3()
    {
        Debug.Log("Buscando arbol de cura");
        float valueN;
        character.Move(character.getInitialBlock(), 0);
        foreach(Hexagon hex in character.game.stage.board)
        {
            if(hex.getState() == Hexagon.CodeState.WalkableE)
            {
                foreach(HealingTree a in arbolesC)
                {
                    float dx = a.hexagon.dx - hex.dx;
                    float dy = a.hexagon.dy - hex.dy;
                    if (Math.Sign(dx) == Math.Sign(dy)) valueN = Math.Abs(dx + dy);
                    else valueN = (Math.Max(Math.Abs(dx), Math.Abs(dy)));
                    AddValue(hex, valueN);

                }
            }
        }
        //foreach(ValueHexagon V in valueHexagon)
        //{
        //    Debug.Log(V.hexagon + " " + V.value + " pre value");
        //}

        Comparer comparer = new Comparer();
        valueHexagon.Sort(comparer);

        //foreach (ValueHexagon V in valueHexagon)
        //{
        //    Debug.Log(V.hexagon + " " + V.value + " post value");
        //}

        foreach (ValueHexagon V in valueHexagon)
        {
            if (!V.hexagon.getOccupant() || V.hexagon.getOccupant() == character)
            {
                character.GetComponent<HimenopioAttack>().s.ShowDecission(Resources.Load<Sprite>("gohealTree"));
                character.StartCoroutine(Move(character, V));
                break;
            }
        }

        character.getStyle().Action(character.getInitialBlock(), 0, character);

        bool there = false;

        foreach (Hexagon hex in character.game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                there = true;
                character.GetComponent<EnemyBehaviourState>().state = new AttackState(character);
                break;
            }
        }
        if (!there) character.StartCoroutine(Wait(character));
        character.GetComponent<EnemyBehaviourState>().state = new WaitingState();
    }
    public void function2()
    {
        Debug.Log("Entrando");
        AttackBuffTree arbol = GameObject.Find("Obstacle2").GetComponent<AttackBuffTree>();
        float valueN;
        character.Move(character.getInitialBlock(), 0);
        foreach(Hexagon hex in character.game.stage.board)
        {
            if(hex.getState() == Hexagon.CodeState.WalkableE)
            {
                float dx = arbol.hexagon.dx - hex.dx;
                float dy = arbol.hexagon.dy - hex.dy;
                if (Math.Sign(dx) == Math.Sign(dy)) valueN = Math.Abs(dx + dy);
                else valueN = (Math.Max(Math.Abs(dx), Math.Abs(dy)));
                AddValue(hex, valueN);
            }
        }
        //foreach (ValueHexagon V in valueHexagon)
        //{
        //    Debug.Log(V.hexagon + " " + V.value + " pre value");
        //}

        Comparer comparer = new Comparer();
        valueHexagon.Sort(comparer);

        //foreach (ValueHexagon V in valueHexagon)
        //{
        //    Debug.Log(V.hexagon + " " + V.value + " post value");
        //}

        foreach (ValueHexagon V in valueHexagon)
        {
            if (!V.hexagon.getOccupant() || V.hexagon.getOccupant() == character)
            {
                character.GetComponent<HimenopioAttack>().s.ShowDecission(Resources.Load<Sprite>("goUpgradeattackTree"));
                character.StartCoroutine(Move(character, V));
                break;
            }
        }

        character.getStyle().Action(character.getInitialBlock(), 0, character);

        bool there = false;

        foreach (Hexagon hex in character.game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                there = true;
                character.GetComponent<EnemyBehaviourState>().state = new AttackState(character);
                break;
            }
        }
        if (!there) character.StartCoroutine(Wait(character));
        character.GetComponent<EnemyBehaviourState>().state = new WaitingState();

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

        //foreach(ValueHexagon V in valueHexagon)
        //{
        //    Debug.Log(V.hexagon + " " + V.value + " pre value");
        //}

        Comparer comparer = new Comparer();
        valueHexagon.Sort(comparer);

        //foreach (ValueHexagon V in valueHexagon)
        //{
        //    Debug.Log(V.hexagon + " " + V.value + " post value");
        //}

        foreach (ValueHexagon V in valueHexagon)
        {
            if (!V.hexagon.getOccupant() || V.hexagon.getOccupant() == character)
            {

                character.GetComponent<HimenopioAttack>().s.ShowDecission(Resources.Load<Sprite>("move"));
                character.StartCoroutine(Move(character, V));          
                break;
            }
        }

        character.getStyle().Action(character.getInitialBlock(), 0, character);

        bool there = false;
        foreach (Hexagon hex in character.game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                there = true;
                character.GetComponent<EnemyBehaviourState>().state = new AttackState(character);
                break;
            }
        }
        if(!there) character.StartCoroutine(Wait(character));
        character.GetComponent<EnemyBehaviourState>().state = new WaitingState();
    }

    public void AddValue(Hexagon direction, float value)
    {
        ValueHexagon component = new ValueHexagon(direction, value);
        valueHexagon.Add(component);
    }

    IEnumerator Move(Character c, ValueHexagon V)
    {
        yield return new WaitForSeconds(2f);
        c.CharacterMove(V.hexagon, false);
    }

    IEnumerator Wait(Character c)
    {
        yield return new WaitForSeconds(2.5f);
        c.GetComponentInChildren<ShowFeedback>().Unshow();
        c.GetComponent<Enemy>().EndTurn();
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




