using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARNCKSOR : EnemyBehaviour
{
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
        this.GetComponent<Enemy>().EndTurn();
    }

    public override int ValueHexagon(Hexagon hex)
    {
        throw new System.NotImplementedException();
    }
}
