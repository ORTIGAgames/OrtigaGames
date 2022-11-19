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
    }
}
