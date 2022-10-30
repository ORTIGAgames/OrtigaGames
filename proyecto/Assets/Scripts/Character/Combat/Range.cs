using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour, Combat
{
    [SerializeField] int maxCasillas;
    public void Action(Hexagon t, int i, Character c)
    {
        i++;
        foreach (Hexagon h in t.neighbours)
        {
            if (h != null)
            {
                if (h.getOccupant())
                {
                    if (h.getOccupant() != c)
                    {
                        if (h.getOccupant().getSide() != c.getSide())
                        {
                            h.setState(Hexagon.CodeState.EnemyT);
                            h.getOccupant().setTarget(true);
                        }
                        else
                        {
                            h.setState(Hexagon.CodeState.AllyT);
                        }
                    }
                    if (i < (((int)c.getMovement()) + 1) && h != null)
                        Action(h, i, c);
                }
                else
                {
                    if (i <= (((int)c.getMovement()) + maxCasillas) && h != null)
                        Action(h, i, c);
                }
            }
        }
    }

    /*public bool Position(Hexagon t, Hexagon t2, int i)
    {
        bool b = false;
        i++;
        foreach (Hexagon h in t.neighbours)
        {
            if (!b)
            {
                if (t2 == h)
                {
                    b = true;
                }
                if (i <= 1 && h != null)
                    b = Position(h, t2, i);
            }            
        }
        return b;
    }*/

    public void ValuablePosition(Hexagon h, int i)
    {
        i++;
        foreach (Hexagon h1 in h.neighbours)
        {
            if (h1 != null && h1.getState() == Hexagon.CodeState.WalkableA)
            {
                h1.setState(Hexagon.CodeState.Action);
            }
            if (i <= maxCasillas - 1 && h1 != null)
                ValuablePosition(h1, i);
        }
    }

    public void Action(Manager m, string d)
    {
        if (d == "Action")
        {
            int damage = (this.GetComponent<Character>().getDamage() <= m.defender.getDefense()) ? 1 : this.GetComponent<Character>().getDamage() - m.defender.getDefense();
            print(damage);
            m.defender.setHealth(m.defender.getHealth() - damage);           
        }

        if (d == "Ability")
        {
            this.GetComponent<Character>().getAbilities().Effect(m.defender);
        }

        this.GetComponent<Character>().CharacterMove(this.GetComponent<Character>().getActualBlock());
        m.CombatDeactivate();
    }
}


