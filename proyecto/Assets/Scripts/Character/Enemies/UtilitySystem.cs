using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitySystem : EnemyBehaviour
{
    public void Action(Character c, List<Enemy> m)
    {
        List<float> values = new List<float>();
        float valueA = Attack(c);
        values.Add(valueA);
        float valueH = Heal(c, m);
        values.Add(valueH);
        float valueS = Summon(c, m);
        values.Add(valueS);

        values.Sort(SortByValue);

        foreach(float f in values)
        {
            print(f);
        }

        float action = values[0];

        if(action > 0 && action == valueA)
        {
            Character weaker = null;
            int weakerLife = int.MaxValue;

            c.getStyle().limitAction(c.getInitialBlock(), -2, c);

            foreach (Hexagon hex in c.game.stage.board)
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
                c.game.CombatActivation(c, weaker);
                c.getStyle().Action(c.game, "Action");
            }
        }

        if(action > 0 && action == valueH)
        {
            c.GetComponent<HARNCKXSHORHealing>().Effect(null);
        }

        if(action > 0 && action == valueS)
        {
            c.GetComponent<HARNCKXSHORSpawner>().Effect(null);
        }
    }

    static int SortByValue(float v1, float v2)
    {
        return v2.CompareTo(v1);
    }

    public float Attack(Character c)
    {
        this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());

        float value = 0;

        foreach (Hexagon hex in c.game.stage.board)
        {
            if (hex.getState() == Hexagon.CodeState.EnemyT)
            {
                value += 1;
            }
        }
        float value2 = (value / 12);
        if (value >= 1)
        {
            return .5f + value2;
        }
        else return 0f;
    }

    public float Heal(Character c, List<Enemy> m)
    {
        int aux;
        if (c.GetComponent<HARNCKXSHORHealing>().cooldown == 0 && m.Count > 0) aux = 1;
        else aux = 0;
        print(aux * (1 - ((float)c.getHealth() / (float)c.MaxHealth)) + " heal");
        return aux * (1 - ((float)c.getHealth() / (float)c.MaxHealth));
    }

    public float Summon(Character c, List<Enemy> m)
    {
        int aux;
        if (c.GetComponent<HARNCKXSHORSpawner>().cooldown == 0) aux = 1;
        else aux = 0;
        print(aux * (1 / ((float)m.Count + 1f)));
        return aux * (1 / ((float)m.Count + 1f));
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
