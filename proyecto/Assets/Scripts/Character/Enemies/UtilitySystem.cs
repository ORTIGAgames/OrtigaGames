using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitySystem : EnemyBehaviour
{
    public void Action(Character c)
    {
        float valueAttack = Attack(c);
        float valueHeal = Heal(c);
        float valueSummon = Summon(c);
    }

    public float Attack(Character c)
    {
        c.getStyle().limitAction(c.getInitialBlock(), -2, c);

        foreach (Hexagon hex in c.game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                return 1.0f;
            }
        }
        return 0f;
    }

    public float Heal(Character c)
    {
        int aux;
        if (c.GetComponent<HARNCKXSHORHealing>().cooldown == 0) aux = 1;
        else aux = 0;

        return aux * (2 / c.getHealth()) + c.GetComponent<ManagerHARNCKXSHOR>().minions.Count;
    }

    public float Summon(Character c)
    {
        int aux;
        if (c.GetComponent<HARNCKXSHORHealing>().cooldown == 0) aux = 1;
        else aux = 0;

        return aux * 1 / c.GetComponent<ManagerHARNCKXSHOR>().minions.Count;
    }

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
        throw new System.NotImplementedException();
    }

    public override int ValueHexagon(Hexagon hex)
    {
        throw new System.NotImplementedException();
    }
}
