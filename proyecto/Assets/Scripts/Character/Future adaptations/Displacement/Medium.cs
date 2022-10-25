using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : MonoBehaviour, DifferentMovement
{
    public void Move(Hexagon t, int i, Hexagon.CodeState s)
    {
        i++;
        foreach (Hexagon h in t.neighbours)
        {
            if (h != null && !h.getOccupant())
            {
                h.setState(s);
            }
            if (i <= 1 && h != null)
                Move(h, i, s);
        }
    }
}
