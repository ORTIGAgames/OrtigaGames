using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCaller : MonoBehaviour
{
    public Ally character;
    public CameraDrag draggin;
    public void CameraActivation()
    {
        if (character)
            character.Camera();
    }
}
