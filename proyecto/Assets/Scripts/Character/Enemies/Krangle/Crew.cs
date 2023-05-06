using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crew : MonoBehaviour
{
    public Manager Game;
    public bool leader;
    public Enemy following;
    public Ally target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void followLeader()
    {
        float valueN = 999999;
        foreach(Enemy e in Game.enemies)
        {
            if(e.GetComponent<Crew>().leader == true)
            {
                print("Hola");
                float auxN;
                Hexagon hex = e.getActualBlock();
                float dx = this.GetComponent<Enemy>().getActualBlock().dx - hex.dx;
                float dy = this.GetComponent<Enemy>().getActualBlock().dy - hex.dy;
                if (Math.Sign(dx) == Math.Sign(dy)) auxN = Math.Abs(dx + dy);
                else auxN = (Math.Max(Math.Abs(dx), Math.Abs(dy)));
                print(auxN + " " + valueN);
                if (auxN <= valueN)
                {
                    print("Adios" + e);
                    valueN = auxN;
                    following = e.GetComponent<Enemy>();
                }
            }
        }
    }

    public void focusEnemy()
    {
        target = (Ally)Game.allies[0];//ponemos de dummy para hacer comprobaciones de distancia
        foreach(Ally a in Game.allies)
        {
            
        }
    }
}
