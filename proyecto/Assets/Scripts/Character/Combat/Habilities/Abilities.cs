using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abilities: MonoBehaviour
{
    public string Role;
    public string Name;
    public abstract void Effect(Character Figther);
}
