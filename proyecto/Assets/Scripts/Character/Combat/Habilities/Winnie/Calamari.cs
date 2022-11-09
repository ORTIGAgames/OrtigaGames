using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamari : Abilities
{
    public void Awake()
    {
        Role = "Support";
    }
    public override void Effect(Character Figther)
    {
        GameObject.Find("Calamari").GetComponent<CalamariPet>().attached = (Ally)Figther;
    }
}

