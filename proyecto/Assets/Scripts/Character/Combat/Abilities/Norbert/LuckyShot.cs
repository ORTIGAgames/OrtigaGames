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
        StartCoroutine(Chance());
    }
    public override void BeforeTurn()
    {
        cooldown--;
    }

    IEnumerator Chance()
    {
        GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Norbert");
        int chanza = Random.Range(0, 11);
        if (chanza % 2 == 0)
        {
            print("ejeje");
            this.GetComponent<Character>().myAnimator.SetTrigger("Win");
            float animationLength = this.GetComponent<Character>().myAnimator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength);
            CombatFigther.setHealth(CombatFigther.getHealth() - 20);
        }
        else
        {
            print("not ejeje");
            this.GetComponent<Character>().myAnimator.SetTrigger("Lose");
            float animationLength = this.GetComponent<Character>().myAnimator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength);
        }
    }
}
