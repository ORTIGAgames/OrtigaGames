using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyShot : Abilities
{
    public Character CombatFigther;
    public void Awake()
    {
        Role = "Damage";
        Name = "LUCKY SHOT";
        description = "Norbert tries a risky strategy in combat, having a 50% chance to success, dealing a big amount of damage to an enemy if hit";
    }
    public override void Effect(Character Figther)
    {
        CombatFigther = Figther;
        int chanza = Random.Range(0, 11);
        if (chanza % 2 == 0)
        {
            GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Norbert");
            CombatFigther.setHealth(CombatFigther.getHealth() - 15);
            this.GetComponent<Character>().myAnimator.SetTrigger("Win");
        }
        else
        {
            this.GetComponent<Character>().myAnimator.SetTrigger("Lose");
        }
    }
    public override void BeforeTurn()
    {
        cooldown--;
    }
}
