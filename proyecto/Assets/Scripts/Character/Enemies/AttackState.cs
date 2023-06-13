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
            if(character.gameObject.name == "Female Himenopio") character.GetComponent<HimenopioAttack>().s.ShowDecission(Resources.Load<Sprite>("femaleAttack"));
            else character.GetComponent<HimenopioAttack>().s.ShowDecission(Resources.Load<Sprite>("maleAttack"));
            character.game.CombatActivation(character, weaker);
            character.getStyle().Action(character.game, "Action");
        }
        character.StartCoroutine(Wait(character));
        character.GetComponent<EnemyBehaviourState>().state = new WaitingState();
    }

    IEnumerator Wait(Character c)
    {
        yield return new WaitForSeconds(2.5f);
        c.GetComponent<Enemy>().EndTurn();
        if(c.GetComponentInChildren<ShowFeedback>()) c.GetComponentInChildren<ShowFeedback>().Unshow();
    }

}
