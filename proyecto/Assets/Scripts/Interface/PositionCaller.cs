using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionCaller : MonoBehaviour
{
    public Ally character;
    public CameraDrag draggin;
    public Button ImageButton;

    public void Update()
    {
        ImageButton.interactable = character.getTurn() == 0 ? false : true;
    }
    public void CameraActivation()
    {
        if (character)
            character.Camera();
    }
}
