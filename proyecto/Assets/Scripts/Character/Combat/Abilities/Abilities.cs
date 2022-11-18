using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Abilities: MonoBehaviour
{
    public string Role;
    public string Name;
    public string description;
    public Image icon;
    public abstract void Effect(Character Figther);
}
