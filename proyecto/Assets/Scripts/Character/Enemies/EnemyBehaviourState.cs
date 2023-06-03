using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviourState: EnemyBehaviour
{
    public State state;

    public void Action()
    {
        state = new MovementState(this.GetComponent<Enemy>());
    }


    public void movement()
    {

    }
    public override Hexagon BestMove(Hexagon hex)
    {
        return new Hexagon();
    }

    public override int ValueHexagon(Hexagon hex)
    {
        return 1;
    }

    public override int DistanceHexagon(Hexagon goal) 
    {
        return 1;
    }
    public int DistanceHexagon(Hexagon goal, Hexagon start)
    {
        return 1;
    }

    public void attack()
    {
        
    }
    public override void EnemyControl()
    {
        
    }

    public Character combat(Hexagon actual, int enemyDistance, int iteration, int range)
    {
        return new Ally();
    }
}
