using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHud : MonoBehaviour//calse para tener referencias a los botonoes y poder desactivarlos y activarlos
{
    public GameObject Action;
    public GameObject Ability;

    public void Start()
    {
        Action = GameObject.Find("Action/Attack");
        Ability = GameObject.Find("AbilityCom");
    }

}
