using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Ally : Character
{
    [SerializeField] protected int character;
    [SerializeField] CinemachineVirtualCamera ncamera;
    [SerializeField] CinemachineBrain worldcamera;
    [SerializeField] CameraDrag drag;

    static int[,] characters;
    static string[] names;


    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        side = "Ally";
        LoadData();
    }

    public void Update()
    {
        if(game.activeAlly != this && !game.CombatH.gameObject.activeSelf)
        {
            if(getInitialBlock().transform.position != this.transform.position)
                this.transform.position = this.getInitialBlock().transform.position + new Vector3(0, .085f, -this.transform.localScale.z);                  
        }
        healthBar.gameObject.SetActive((game.activeAlly == this || game.lastClicked == this) ? true : false);
        if (Health < MaxHealth / 4) ActualFace = Face[1];
        else ActualFace = Face[0];
    }
    void LoadData()
    {
        characters = BetweenScenesControler.characters;
        names = BetweenScenesControler.names;

        MaxHealth = characters[character, 0];
        //Debug.Log(Health);
        Damage = characters[character, 1];
        //Debug.Log(Damage);
        Defense = characters[character, 2];
        //Debug.Log(Defense);
        Speed = characters[character, 2];
        //Debug.Log(Speed);
        Name = names[character];
        //Debug.Log(Name);
        Health = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
    public override void OnMouseDown()
    {
        Camera();
        if (this.targetable && game.lastClicked.getSide() == side && game.allyturn)//si esta a rango
        {
            if (game.activeAlly.getActualBlock().getState() == Hexagon.CodeState.Action && game.lastClicked == this)//si esta a rango de combate se pegan
            {
                game.CombatActivation(game.activeAlly, this);
            }
            else//si no esta a rango de combate pero podria estarlo se muestran las casillas donde se podria pegar
            {
                game.lastClicked = this;
                game.stage.NoAttacks();
                game.activeAlly.getStyle().ValuablePosition(this.InitialBlock, 0);
            }
        }
        else if (game.allyturn && turn > 0)
        {
            if(game.activeAlly) game.activeAlly.GetComponent<BoxCollider>().enabled = true;
            game.PlayerReset();
            //game.lastClicked = this;
            game.InteractionActivate();
            game.setActiveAlly(this);
            game.CharacterActivate(ActualFace, NameIcon, Damage.ToString(), Defense.ToString(), MaxHealth, this.GetComponent<Abilities>().Name, this.GetComponent<Abilities>().description, this.GetComponent<Abilities>().icon);
            game.lastAction = this.InitialBlock;
            this.ActualBlock = this.InitialBlock;
            game.activeAlly.GetComponent<BoxCollider>().enabled = false;
            game.stage.Reset();//para mostrar las casillas donde se esparce en el tablero se resetea   
            this.Move(this.InitialBlock, 0);
            style.Action(this.InitialBlock, 0, this);
        }
        game.lastClicked = this;
    }

    private void OnMouseOver()
    {
        drag.Activated = false;
    }

    public override void Move(Hexagon t, int i)//Manera mas simple de implementar movimiento con uno de casillas individuales que avanza en bucle según un determinado enumerador
    {
        t.setState(Hexagon.CodeState.WalkableA);//cambiar para que si hay un obstaculo ya no se pueda pasar
        i++;
        foreach (Hexagon h in t.neighbours)
        {
            if (h != null && !h.getOccupant())
            {
                if(h.transform.childCount <= 0 || (h.transform.GetChild(0).name != "Obstacle" && h.transform.GetChild(0).name != "Obstacle2"))
                {
                    h.setState(Hexagon.CodeState.WalkableA);
                    if (i <= ((int)displacement) && h != null)
                        Move(h, i);
                }
            }
        }        
    }

    public override void Cancel()
    {
        game.stage.Reset();
        game.PlayerReset();
        game.InteractionDeactivate();
        game.CharacterDeactivate();
        if(game.CombatH)
            game.CombatDeactivate();
        this.GetComponent<BoxCollider>().enabled = true;
    }

    public void Camera()
    {
        worldcamera.ActiveVirtualCamera.Priority = 10;
        ncamera.Priority = 100;
    }

    public override void CharacterMove(Hexagon h, bool c)
    {
        this.transform.position = h.transform.position + new Vector3(0, .085f, -0.05f);
        InitialBlock.setOccupant(null);
        this.InitialBlock = h;
        h.setOccupant(this);
        this.GetComponent<BoxCollider>().enabled = true;
        game.PlayerReset();
        game.stage.Reset();
        game.InteractionDeactivate();
        game.lastAction = null;
        if(!c)
            EndTurn();
        game.CharacterDeactivate();
    }
    public override void ShowMove(Hexagon h)
    {
        this.transform.position = h.transform.position + new Vector3(0, .085f, -0.05f);
        this.setActualBlock(h);
        game.lastAction = h;
    }

    public override void EndTurn()
    {
        turn--;
    }
}
