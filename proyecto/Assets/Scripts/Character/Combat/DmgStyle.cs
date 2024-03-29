using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgStyle : MonoBehaviour, Combat
{
    public int maxCasillas;
    public Character defender;
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
                            if (this.GetComponentInParent<Abilities>() && this.GetComponentInParent<Abilities>().Role == "Support" || h.getOccupant().getSide() == "Enemy")
                                h.setState(Hexagon.CodeState.AllyT);
                        }
                    }
                    if(maxCasillas > 1 && i <= (int)c.getMovement() + 2)
                        limitAction(h, 0, c);
                }
                else
                {
                    if (h.transform.childCount > 0 && h.transform.GetChild(0).name == "Obstacle")
                    {
                        if (maxCasillas > 1 && i <= (int)c.getMovement() + 2)
                            limitAction(h, 0, c);
                    }
                    else
                    {
                        if (i <= (int)c.getMovement() + maxCasillas)
                            Action(h, i, c);
                    }
                }
            }
        }
    }

    public void limitAction(Hexagon t, int i, Character c)
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
                            if (this.GetComponentInParent<Abilities>() && this.GetComponentInParent<Abilities>().Role == "Support")
                                h.setState(Hexagon.CodeState.AllyT);
                        }
                    }
                }
                if (i < maxCasillas - 3)
                    limitAction(h, i, c);
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
        defender = m.defender;
        this.GetComponent<Character>().CharacterMove(this.GetComponent<Character>().getActualBlock(), true);
        if (d == "Action")
        {
            if (maxCasillas > 1) FindObjectOfType<AudioManager>().Play("Range");
            else FindObjectOfType<AudioManager>().Play("Melee");
            this.GetComponent<Character>().myAnimator.SetTrigger("Attack");                    
        }

        if (d == "Ability")
        {
            if (this.GetComponent<Character>().myAnimator.parameterCount > 0)
            {
                this.GetComponent<Character>().myAnimator.SetTrigger("Ability");
            }
            else//cambiar cuando todos tengan animacion de ataque, quitar esta linea
            {
                this.GetComponent<Character>().getAbilities().Effect(defender);
                this.GetComponent<Character>().EndTurn();
            }
        }
        this.GetComponent<Character>().game.CombatDeactivate();
    }

    public void AbilitySequence()
    {
        this.GetComponent<Character>().getAbilities().Effect(defender);
        this.GetComponent<Character>().EndTurn();
    }
    public void AttackSequence()
    {
        int damage = (this.GetComponent<Attack>().Action() <= defender.getDefense()) ? 1 : this.GetComponent<Attack>().Action() - defender.getDefense();
        defender.setHealth(defender.getHealth() - damage);
        this.GetComponent<Character>().EndTurn();
    }
}


