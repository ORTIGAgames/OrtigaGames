using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class Ixoda : EnemyBehaviour
{

Ally closest;
int turns;
Random random = new Random();

//DECISION FACTORS
double fatigue;
double fear;
double motivation;
int odds;
void Start(){
    turns=0;
}

public void utilSystem(){

//DECISION FACTORS
fatigue= Math.Pow(turns,2)/60.0;
fear= 1-((AllyDistance()-1)/(2.5-1));
motivation= (1-fatigue-(fear/2));
odds= random.Next(0,10);


print("fatiga: "+fatigue+" miedo: "+fear+" motivacion: "+ motivation+" turns: "+turns);


if(motivation>0.6&&odds==7){

   for(int i=0;i<2;i++){ //BIG JUMP
       EnemyControl();
    }
    print("SALTO");
}else if(fear>0.6&&odds%2==0){
    print("HUIR");
    ScaredAway(); //RUN AWAY FROM ALLY
}else{
    print("AVANZAR");
    EnemyControl();
}

//ACCIONES
/*
    EnemyControl(); //ANDAR
    ScaredAway(); //HUIR
for(int i=0;i<2;i++){ //SALTAR
    EnemyControl();
}
*/
    turns++;
  this.GetComponent<Enemy>().EndTurn();

}



public float AllyDistance(){
float distance=0;

foreach (Ally a in allies)
{
    float aux= Vector3.Distance(transform.position,a.transform.position);
    
    if(distance<aux){
        distance=aux;
        closest=a;
    }
    
}

    return distance;
}




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





    //ACCIÓN 1 y ACCIÓN 2
    public override void EnemyControl()
    {
      print(AllyDistance());

  
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
                    
                    this.GetComponent<Enemy>().CharacterMove(h, false);
                    break;
                }

            }
        }
        print(this.GetComponent<Character>());
        print(movement);
       // this.GetComponent<Enemy>().EndTurn();
    }
    public override int ValueHexagon(Hexagon hex)
    {
       
        //Buscar la casilla de salida y poner valor en -- por cada vecina
        int value = DistanceHexagon(hex);
        return value;
    }

  public  void ScaredAway()
    {
      print(AllyDistance());
        //Movement
        this.GetComponent<Enemy>().setActualBlock(this.GetComponent<Enemy>().getInitialBlock());
        this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>()); 
        Hexagon movement = this.GetComponent<Enemy>().getActualBlock(); 
        
        for (int i = 0; i <= ((int)this.GetComponent<Enemy>().getMovement()); i++) //segun tu rango de movement
        {
            Hexagon aux = BestMoveScared(movement);   //aux es el mejor vecino de movement
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
   // this.GetComponent<Enemy>().EndTurn();
    }

public  Hexagon BestMoveScared(Hexagon hex)
    {
        //lista con los vecinos
        List<Hexagon> movement = hex.neighbours;
        
        var value = 0;
        Hexagon bestHexagon = hex;
        foreach (Hexagon a in movement)
        {
            if(a != null) //si existe ese vecino
            {
                
                var tempValue = ValueHexagonScared(a);    //se calcula su valor
                if (tempValue < value) 
                {
                    value = tempValue;
                    bestHexagon = a;
                }
            }
            
        }
        return bestHexagon;     //se queda el de mejpr valor
    }


    public  int ValueHexagonScared(Hexagon hex)
    {
       
        //Valor es mas grande cuanto mas lejos esté del aliado cercano
        int value = (int)Vector3.Distance(hex.transform.position,closest.transform.position);
        return value;
    }
}

