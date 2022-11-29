using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "SPORE";
        description = "Declan shakes his spores out of his body, giving one ally an extra turn";
    }
    public override void Effect(Character Figther)
    {
        GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Declan");
        Figther.setTurn(Figther.getTurn() + 1);
        EffectKeeper effect = GameObject.Find("Effects").GetComponent<EffectKeeper>();
        FeedBack indicator = Instantiate(Figther.FeedbackResponse, Figther.transform.position, Quaternion.identity).GetComponent<FeedBack>();
        indicator.SetAction(-1, effect.Effect(2), .5f);//cambiar a un sprite que sea de daño
    }
    public override void BeforeTurn()
    {
        cooldown--;
    }
}
