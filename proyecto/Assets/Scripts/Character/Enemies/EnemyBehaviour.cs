using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    public abstract Hexagon BestMove(Hexagon hex);

    public abstract int ValueHexagon(Hexagon hex);

    public abstract int DistanceHexagon(Hexagon goal); //Esto hay que cambiarlo porque xd

    public abstract void EnemyControl();
}
