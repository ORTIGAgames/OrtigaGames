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
        float valueN = 999999;
        foreach (Ally a in Game.allies)//marca a quien hacer focus
        {
            float auxN;
            Hexagon hex = a.getActualBlock();
            float dx = this.GetComponent<Enemy>().getActualBlock().dx - hex.dx;
            float dy = this.GetComponent<Enemy>().getActualBlock().dy - hex.dy;
            if (Math.Sign(dx) == Math.Sign(dy)) auxN = Math.Abs(dx + dy);
            else auxN = (Math.Max(Math.Abs(dx), Math.Abs(dy)));
            if (auxN <= valueN)
            {
                valueN = auxN;
                target = a.GetComponent<Ally>();
            }
        } 

        foreach(Enemy e in Game.enemies)//a quienes le sigan le indica ue vayan a por ellos
        {
            if(e.GetComponent<Crew>().following == this.GetComponent<Enemy>())
            {
                e.GetComponent<Crew>().target = this.target;
            }
        }
    }
}
