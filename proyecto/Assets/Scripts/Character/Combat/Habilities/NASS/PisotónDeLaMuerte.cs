using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisotónDeLaMuerte : Abilities
{
    public void Awake()
    {
        Role = "Damage";
        Name = "Death Stomp";
    }
    public override void Effect(Character Figther)
    {
        foreach(Hexagon h in this.GetComponent<Character>().getActualBlock().neighbours)
        {
            if(h && h.getOccupant() && h.getOccupant().getSide() != this.GetComponent<Character>().getSide())
            {
                int damage = (this.GetComponent<Character>().getDamage()/3 <= h.getOccupant().getDefense()) ? 1 : this.GetComponent<Character>().getDamage()/6 - h.getOccupant().getDefense();
                h.getOccupant().setHealth(h.getOccupant().getHealth() - damage);
            }               
        }
    }
}
