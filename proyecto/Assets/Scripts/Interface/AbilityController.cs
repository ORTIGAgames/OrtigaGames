using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    [SerializeField] Button btn;
    public GameObject Ability;

    public void AbilityA()
    {
        if (!Ability.active)
            Ability.SetActive(true);
        else
            Ability.SetActive(false);
    }
}