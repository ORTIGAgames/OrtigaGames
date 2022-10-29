using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        side = "Enemy";

        MaxHealth = 35;
        Debug.Log(Health);
        Damage = 5;
        Debug.Log(Damage);
        Defense = 5;
        Debug.Log(Defense);
        Speed = 5;
        Debug.Log(Speed);
        Name = "Enemigo";
        Debug.Log(Name);
        Health = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (turn > 0)
        {
            Invoke("minusturn", 2.0f);
        }
    }

    void minusturn()
    {
        if (turn > 0)
        {
            turn--;
            
        }
    }

    public override void OnMouseDown()
    {
        if (game.activeAlly)//si el jugador esta con un personaje activo
        {
            if (this.targetable)//si esta a rango
            {
                if (game.activeAlly.getActualBlock().getState() == Hexagon.CodeState.Action && game.activeEnemy == this)//si esta a rango de combate se pegan
                {
                    game.CombatActivation(game.activeAlly, this);
                }
                else//si no esta a rango de combate pero podria estarlo se muestran las casillas donde se podria pegar
                {
                    game.activeEnemy = this;
                    game.stage.NoAttacks();
                    game.activeAlly.getStyle().ValuablePosition(this.InitialBlock, 0);
                }
            }
        }
        else//si el jugador no esta con ningun personaje activo
        {
            game.stage.Reset();//para mostrar las casillas donde se esparce en el tablero se resetea
            game.activeEnemy = this;
            game.InteractionActivate();
            this.Move(this.InitialBlock, 0);
            style.Action(this.InitialBlock, 0, this);
        }
    }

    public void Cancel()
    {
        game.stage.Reset();
        game.PlayerReset();
        game.InteractionDeactivate();
    }

    public override void Move(Hexagon t, int i) //Manera mas simple de implementar movimiento con uno de casillas individuales que avanza en bucle según un determinado enumerador
    {
        t.setState(Hexagon.CodeState.WalkableE);
        i++;
        foreach (Hexagon h in t.neighbours)
        {
            if (h != null && (!h.getOccupant() || h.getOccupant().getSide() == "Enemy"))
            {
                h.setState(Hexagon.CodeState.WalkableE);
                if (i <= ((int)displacement) && h != null)
                    Move(h, i);
            }
        }
    }

    public override void CharacterMove(Hexagon h)
    {
        this.transform.position = h.transform.position + new Vector3(0, .05f, 0);
        InitialBlock.setOccupant(null);
        this.InitialBlock = h;
        h.setOccupant(this);
        game.activeAlly = null;
        game.PlayerReset();
        game.stage.Reset();
    }
    public override void ShowMove(Hexagon h)
    {
        this.transform.position = h.transform.position + new Vector3(0, .05f, 0);
    }

    public Hexagon BestMove(Hexagon hex)
    {
        Hexagon[] movement = hex.neighbours;
        var value = -1000;
        Hexagon bestHexagon = hex;
        foreach(Hexagon a in movement)
        {
            var tempValue = ValueHexagon(a);
            if (tempValue > value)
            {
                value = tempValue;
                bestHexagon = a;
            }
        }
        return bestHexagon;
    }

    public int ValueHexagon(Hexagon hex)
    {
        var value = -1000;
        foreach(Ally a in game.allies) 
        {
            int tempvalue = (40 * 2 - a.getHealth()) - DistanceHexagon(a.getActualBlock());
            if (tempvalue > value)
                value = tempvalue;
        }
        return value;
    }

    public int DistanceHexagon(Hexagon goal ) //Esto hay que cambiarlo porque xd
    {
        Vector3 goalPos = goal.transform.position;
        Vector3 currentPos = getActualBlock().transform.position;

        Vector3 distance = goalPos - currentPos;

        return (int) Mathf.Round(distance.magnitude);

        /*
        foreach(Hexagon a in goal.neighbours)
        {
            if (a == ActualBlock)
                return distance;
            else
                distance++;
                DistanceHexagon(a,distance);
        }
        return distance;*/
    }

    public void EnemyControl()
    {
        Hexagon movement = getActualBlock();
        for (int i = 0; i < ((int)displacement); i++)
        {
            movement = BestMove(movement);
        }
        CharacterMove(movement);

    }
}
