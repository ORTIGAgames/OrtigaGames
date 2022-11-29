using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Abilities: PreTurn
{
    public int CoolDown;
    public string Role, Name, description;
    public Sprite icon, ActiveIcon;
    public abstract void Effect(Character Figther);
}
