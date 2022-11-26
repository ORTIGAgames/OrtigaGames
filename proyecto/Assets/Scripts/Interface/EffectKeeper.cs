using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectKeeper : MonoBehaviour
{
    public List<Sprite> spriteEffect = new List<Sprite>();
    
    public Sprite Effect(int access)
    {
        return spriteEffect[access];
    }
}
