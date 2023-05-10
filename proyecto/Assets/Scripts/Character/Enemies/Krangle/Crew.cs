using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class Crew : MonoBehaviour
{
    public ManagerKrangle Game;
    public bool leader;
    public Enemy following;
    public Ally target;
    public Image TargetSprite;

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
        setTarget(following.GetComponent<Crew>().target);
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
                valueN = auxN;
                target = a.GetComponent<Ally>();
            }
        }

        setTarget(target);

        Game.chosen.Remove(target);

        foreach (Enemy e in Game.enemies)//a quienes le sigan le indica ue vayan a por ellos
        {
            if(e.GetComponent<Crew>().following == this.GetComponent<Enemy>())
            {
                e.GetComponent<Crew>().setTarget(this.target);
            }
        }
    }


    public void setTarget(Character c)
    {
        print("he llegado");
        target = (Ally)c;
        TargetSprite.gameObject.SetActive(true);
        TargetSprite.sprite = target.GetComponent<Character>().getFace();
    }
}
