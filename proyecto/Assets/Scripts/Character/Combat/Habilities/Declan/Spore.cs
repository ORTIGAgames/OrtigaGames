using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore :Abilities
{
    public void Awake()
    {
        Role = "Support";
    }
    public override void Effect(Character Figther)
    {
        print("hello");
    }
}
