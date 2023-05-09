using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Crew : MonoBehaviour
{
    public ManagerKrangle Game;
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
                float auxN;
                Hexagon hex = e.getActualBlock();
                float dx = this.GetComponent<Enemy>().getActualBlock().dx - hex.dx;
                float dy = this.GetComponent<Enemy>().getActualBlock().dy - hex.dy;
                if (Math.Sign(dx) == Math.Sign(dy)) auxN = Math.Abs(dx + dy);
                else auxN = (Math.Max(Math.Abs(dx), Math.Abs(dy)));
                if (auxN <= valueN)
                {
                    valueN = auxN;
                    following = e.GetComponent<Enemy>();
                }
            }
        }
        target = following.GetComponent<Crew>().target;
    }

    public void focusEnemy()
    {
        float valueN = 999999;
        foreach (Character a in Game.chosen.ToList())//marca a quien hacer focus
        {
            float auxN;
            Hexagon hex = a.getActualBlock();
            float dx = this.GetComponent<Enemy>().getActualBlock().dx - hex.dx;
            float dy = this.GetComponent<Enemy>().getActualBlock().dy - hex.dy;
            if (Math.Sign(dx) == Math.Sign(dy)) auxN = Math.Abs(dx + dy);
            else auxN = Math.Max(Math.Abs(dx), Math.Abs(dy));
            if (auxN <= valueN)
            {
                print(a.GetComponent<Ally>());
                valueN = auxN;
                target = a.GetComponent<Ally>();
            }
        }

        Game.chosen.Remove(target);

        foreach (Enemy e in Game.enemies)//a quienes le sigan le indica ue vayan a por ellos
        {
            if(e.GetComponent<Crew>().following == this.GetComponent<Enemy>())
            {
                e.GetComponent<Crew>().target = this.target;
            }
        }
    }
}
