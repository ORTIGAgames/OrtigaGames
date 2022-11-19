using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    [SerializeField] Button btn;
    public GameObject Ability;
    public Button AbilityCaller;

    public void AbilityA()
    {
        if (!Ability.activeSelf)
            Ability.SetActive(true);
        else
            Ability.SetActive(false);
    }
}