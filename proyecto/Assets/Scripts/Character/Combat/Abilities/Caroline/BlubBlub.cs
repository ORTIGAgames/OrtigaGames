using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlubBlub : Abilities
{
    public void Awake()
    {
        cooldown = new CoolDown();
        Role = "Damage";
        Name = "BLUB BLUB";
        description = "Brulb blub bulb blub BLUUUUUB (Caroline overcharges her cannon, throwing a SUPER MISSILE to an enemy, damaging the surrounding zone)";
    }
    public override void Effect(Character Figther)
    {
        GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Caroline");
        int damage;
        foreach (Hexagon h in Figther.getActualBlock().neighbours)
        {
            if (h && h.getOccupant() && h.getOccupant().getSide() != this.GetComponent<Character>().getSide())
            {
                damage = (int)((this.GetComponent<Character>().getDamage() / 1.75 <= h.getOccupant().getDefense()) ? 1 : this.GetComponent<Character>().getDamage() / 1.75 - h.getOccupant().getDefense());
                h.getOccupant().setHealth(h.getOccupant().getHealth() - damage);
                print(damage);
            }
        }
        damage = (int)((this.GetComponent<Character>().getDamage() / 1.75 <= Figther.getDefense()) ? 1 : this.GetComponent<Character>().getDamage() / 1.75 - Figther.getDefense());
        Figther.setHealth(Figther.getHealth() - damage);
        print(damage);
    }
}
