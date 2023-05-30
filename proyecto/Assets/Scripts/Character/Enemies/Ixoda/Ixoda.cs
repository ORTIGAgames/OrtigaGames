using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ixoda : EnemyBehaviour
{
    public override Hexagon BestMove(Hexagon hex)
    {
        //lista con los vecinos
        List<Hexagon> movement = hex.neighbours;
        
        var value = 1000;
        Hexagon bestHexagon = hex;
        foreach (Hexagon a in movement)
        {
            if(a != null) //si existe ese vecino
            {
                
                var tempValue = ValueHexagon(a);    //se calcula su valor
                if (tempValue < value) //si es mas grande que 1000, pasa a ser el mejor
                {
                    value = tempValue;
                    bestHexagon = a;
                }
            }
            
        }
        return bestHexagon;     //se queda el de mejpr valor
    }

    public override int DistanceHexagon(Hexagon current) 
    {
        
        int dx = (-7) - current.dx ;

        int dy = 4 - current.dy;
        
        if (Math.Sign(dx) == Math.Sign(dy))
            return(Math.Abs(dx + dy));
        else
            return(Math.Max(Math.Abs(dx), Math.Abs(dy)));
   
    }

    public override void EnemyControl()
    {
        //Movement
        this.GetComponent<Enemy>().setActualBlock(this.GetComponent<Enemy>().getInitialBlock());
        this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>()); 
        Hexagon movement = this.GetComponent<Enemy>().getActualBlock(); 
        
        for (int i = 0; i <= ((int)this.GetComponent<Enemy>().getMovement()); i++) //segun tu rango de movement
        {
            Hexagon aux = BestMove(movement);   //aux es el mejor vecino de movement
            movement = aux;         //se hace tantas veces como su rango de movimiento
        }

        if (!movement.getOccupant())
            this.GetComponent<Enemy>().CharacterMove(movement, false);
        else
        {
            foreach (Hexagon h in movement.neighbours)
            {
                if (h && !h.getOccupant())
                {
                    print(this.GetComponent<Character>());
                    print(h);
                    this.GetComponent<Enemy>().CharacterMove(h, false);
                    break;
                }

            }
        }
        print(this.GetComponent<Character>());
        print(movement);
        /*foreach (Hexagon h in movement.neighbours)
        {
            if (h.getOccupant() != null)
                this.GetComponent<Enemy>().setTurn(this.GetComponent<Enemy>().getTurn() + 1);
        }*/

        this.GetComponent<Enemy>().EndTurn();
    }

    public override int ValueHexagon(Hexagon hex)
    {
        
        //Buscar la casilla de salida y poner valor en -- por cada vecina
        int value = DistanceHexagon(hex);
        return value;
    }
}
