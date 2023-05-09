using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public Manager Game;
    Enemy en;
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

        print(this.GetComponent<Enemy>() + " Ability executed " + en);

    }

    void Heal()
    {
        en.setHealth(en.getHealth() + 2);
        print("Curado");
    }

    void DmgBoost()
    {
        en.setDamage(en.getDamage() + 2);
        print("Daño");
    }

    void RangeBoost()
    {
        en.GetComponent<DmgStyle>().maxCasillas += 1;
        print("Rango");
        print(en.GetComponent<DmgStyle>().maxCasillas);
    }
}
