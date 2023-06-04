using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARNCKXSHORHealing : Abilities
{
    public List<Enemy> minions;

    public override void Effect(Character Figther)
    {

        minions = GameObject.Find("Manager").GetComponent<ManagerHARNCKXSHOR>().minions;
        foreach(Enemy m in minions.ToArray())
        {
            foreach(Hexagon h in this.GetComponent<Enemy>().getActualBlock().neighbours){
                
                    foreach (Hexagon e in h.neighbours)
                    {
                        if (e == m.GetComponent<Enemy>().getActualBlock() || h == m.GetComponent<Enemy>().getActualBlock())
                        {
                            this.GetComponent<Enemy>().setHealth(this.GetComponent<Enemy>().getHealth() + 5);
                            this.GetComponent<Enemy>().game.DeleteCharacter(m);
                            break;
                        }
                    }
            }
        }
    }

    public override void BeforeTurn()
    {
       
    }
}
