using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamari : Abilities
{
    public void Awake()
    {
        Role = "Support";
        Name = "CALAMARI'S TOUCH";
        description = "Winnie grants her faithful Calamari to an ally, healing a small amount of health at the start of each turn to whoever has her at that moment";
    }

    public override void Effect(Character Figther)
    {
        GameObject.Find("Calamari").GetComponent<CalamariPet>().attached = (Ally)Figther;
    }
}

