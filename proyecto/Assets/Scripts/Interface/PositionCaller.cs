using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionCaller : MonoBehaviour
{
    public Ally character;
    public CameraDrag draggin;
    public Button ImageButton;
    public List<Sprite> images = new List<Sprite>();

    public void Update()
    {
        if (character.getHealth() < character.MaxHealth / 4) ImageButton.image.sprite = images[0];
        else ImageButton.image.sprite = images[1];
        ImageButton.interactable = character.getTurn() == 0 ? false : true;
    }
    public void CameraActivation()
    {
        if (character)
            character.Camera();
    }
}
