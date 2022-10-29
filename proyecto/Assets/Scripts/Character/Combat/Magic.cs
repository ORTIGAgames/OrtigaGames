using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour, Combat
{
    public void Action(Hexagon t, int i, Character c)
    {

    }

    /*public bool Position(Hexagon t, Hexagon t2, int i)
    {
        i++;
        foreach (Hexagon h in t.neighbours)
        {
            if (t2 == h)
            {
                return true;
            }
            if (i <= 1 && h != null)
                Position(h, t2, i);
        }
        return false;
    }*/

    public void ValuablePosition(Hexagon h, int i)
    {

    }

    public void Action(Manager m, string d)
    {

    }
}
