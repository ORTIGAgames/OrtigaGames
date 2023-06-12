using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Enemy character;
    public AttackState(Enemy c)
    {
        character = c;
        character.game.stage.Reset();
        function();
    }
    public override void function()
    {
        Debug.Log("Attack state");

        Character weaker = null;
        int weakerLife = int.MaxValue;

        character.getStyle().limitAction(character.getInitialBlock(), -3, character);

        foreach (Hexagon hex in character.game.stage.board)
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
            character.GetComponent<HimenopioAttack>().s.ShowDecission(Resources.Load<Sprite>("gohealTree"));
            Attack(character, weaker);
        }
        character.StartCoroutine(Wait(character));
        character.GetComponent<EnemyBehaviourState>().state = new WaitingState();
    }

    IEnumerator Attack(Character c, Character w)
    {
        yield return new WaitForSeconds(2f);
        character.game.CombatActivation(c, w);
        character.getStyle().Action(character.game, "Action");
    }

    IEnumerator Wait(Character c)
    {
        yield return new WaitForSeconds(2.5f);
        c.GetComponentInChildren<ShowFeedback>().Unshow();
        c.GetComponent<Enemy>().EndTurn();
    }

}
