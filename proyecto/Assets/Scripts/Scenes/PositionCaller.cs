using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCaller : MonoBehaviour
{
    public Ally character;

    public void CameraActivation()
    {
        if (character)
            character.Camera();
    }
}
