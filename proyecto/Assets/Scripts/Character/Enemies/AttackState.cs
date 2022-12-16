using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Enemy character;
    public AttackState(Enemy c)
    {
        character = c;
        function();
    }
    public override void function()
    {
        Character weaker = null;
        int weakerLife = 100;

        character.getStyle().Action(this.GetComponent<Character>().getInitialBlock(), 0, this.GetComponent<Character>());

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
            character.game.CombatActivation(this.GetComponent<Enemy>(), weaker);
            character.getStyle().Action(this.GetComponent<Enemy>().game, "Action");
        }
        character.EndTurn();
        character.GetComponent<EnemyBehaviourState>().State = new WaitingState();
    }
}
