using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Character character;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI MaxHealthText;

    public void Update()
    {
        if(character)
            setHealth(character.getHealth());
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        if(MaxHealthText)
            MaxHealthText.text = health.ToString();

        fill.color = gradient.Evaluate(1f);

    }
    private void setHealth(int health)
    {
        slider.value = health;
        if(HealthText)
            HealthText.text = health.ToString();

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

