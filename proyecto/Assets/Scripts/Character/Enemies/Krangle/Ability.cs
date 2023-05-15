using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public Manager Game;
    Enemy en;

    private void Awake()
    {
        Game = GameObject.Find("Manager").GetComponent<Manager>();
    }
    public void Execution(Enemy e)
    {
        en = e;
        float healthValue = (float)(e.getHealth() - 0) / (e.MaxHealth - 0);

        int rValue = 0;

        e.GetComponent<DmgStyle>().Action(e.GetComponent<Enemy>().getActualBlock(), 0, e.GetComponent<Enemy>());
        foreach(Ally a in Game.allies)
        {
            if (a.getTarget() == true) rValue = 1;
        }
        Game.stage.Reset();

        if (healthValue > 0.5)
        {
            if (rValue == 1) DmgBoost();
            else RangeBoost();
        }
        else Heal();

    }

    void Heal()
    {
        en.setHealth(en.getHealth() + 2);
    }

    void DmgBoost()
    {
        en.setDamage(en.getDamage() + 2);
    }

    void RangeBoost()
    {
        en.GetComponent<DmgStyle>().maxCasillas += 1;
    }
}
