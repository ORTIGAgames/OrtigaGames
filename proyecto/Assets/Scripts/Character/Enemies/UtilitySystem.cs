using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitySystem : EnemyBehaviour
{
    public void Action(Character c)
    {
        List<float> values = new List<float>();
        float valueA = Attack(c);
        values.Add(valueA);
        float valueH = Heal(c);
        values.Add(valueH);
        float valueSu = Summon(c);
        values.Add(valueSu);
        
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
        return aux * (2 / c.getHealth()) + c.GetComponent<ManagerHARNCKXSHOR>().minions.Count;//hay que normalzarlo entre valores para que devuelva 1 o 0
    }

    public float Summon(Character c)
    {
        int aux;
        if (c.GetComponent<HARNCKXSHORHealing>().cooldown == 0) aux = 1;
        else aux = 0;

        return aux * 1 / c.GetComponent<ManagerHARNCKXSHOR>().minions.Count;//hay que normalzarlo entre valores para que devuelva 1 o 0
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
