using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlubBlub : Abilities
{
    public void Awake()
    {
        Role = "Damage";
        Name = "BLUB BLUB";
        description = "Brulb blub bulb blub BLUUUUUB (Caroline overcharges her cannon, throwing a SUPER MISSILE to an enemy, damaging the surrounding zone)";
    }
    public override void Effect(Character Figther)
    {
        int damage;
        damage = (this.GetComponent<Character>().getDamage() <= Figther.getDefense()) ? 1 : this.GetComponent<Character>().getDamage() / 3 - Figther.getDefense();
        Figther.setHealth(Figther.getHealth() - damage);
        foreach (Hexagon h in Figther.getActualBlock().neighbours)
        {
            if (h && h.getOccupant() && h.getOccupant().getSide() != this.GetComponent<Character>().getSide())
            {
                damage = (this.GetComponent<Character>().getDamage() <= h.getOccupant().getDefense()) ? 1 : this.GetComponent<Character>().getDamage() / 3 - h.getOccupant().getDefense();
                h.getOccupant().setHealth(h.getOccupant().getHealth() - damage);
            }
        }        
    }
}
