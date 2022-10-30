using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Ally : Character
{
    [SerializeField] protected int character;
    [SerializeField] CinemachineVirtualCamera camera;
    [SerializeField] CinemachineBrain worldcamera;

    static int[,] characters;
    static string[] names;


    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        side = "Ally";
        LoadData();
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
        if(game.allyturn == true && turn > 0)
        {
            worldcamera.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            camera.gameObject.SetActive(true);
            game.InteractionActivate();
            if (game.activeAlly)
            {
                if (game.activeAlly.transform.position != game.activeAlly.getInitialBlock().transform.position)//cuando se haga la gestión de turnos y cada personaje tenga un movimiento y una accion sustituir esto por si no se ha movido
                    game.activeAlly.transform.position = game.activeAlly.getInitialBlock().transform.position + new Vector3(0, .075f, 0);
                game.activeAlly.GetComponent<BoxCollider>().enabled = true;
            }

            game.PlayerReset();

            if (!game.CombatH.active)
            {
                game.setActiveAlly(this);
                game.CharacterActivate(Face, Name, Damage.ToString(), Defense.ToString(), Speed.ToString(), Health, MaxHealth);
                game.lastAction = this.InitialBlock;
                this.ActualBlock = this.InitialBlock;
                game.activeAlly.GetComponent<BoxCollider>().enabled = false;
            }
            game.stage.Reset();//para mostrar las casillas donde se esparce en el tablero se resetea   
            this.Move(this.InitialBlock, 0);
            style.Action(this.InitialBlock, 0, this);
        }       
    }

    public override void Move(Hexagon t, int i)//Manera mas simple de implementar movimiento con uno de casillas individuales que avanza en bucle según un determinado enumerador
    {
        t.setState(Hexagon.CodeState.WalkableA);//cambiar para que si hay un obstaculo ya no se pueda pasar
        i++;
        foreach (Hexagon h in t.neighbours)
        {
            if (h != null && !h.getOccupant())
            {
                h.setState(Hexagon.CodeState.WalkableA);
                if (i <= ((int)displacement) && h != null)
                    Move(h, i);
            }
        }
    }

    public void Cancel()
    {
        if (game.activeAlly)
        {
            if (game.activeAlly.transform.position != game.activeAlly.getInitialBlock().transform.position)
                game.activeAlly.transform.position = game.activeAlly.getInitialBlock().transform.position + new Vector3(0, .075f, 0);
            game.activeAlly.GetComponent<BoxCollider>().enabled = true;
        }
        game.stage.Reset();
        game.PlayerReset();
        game.InteractionDeactivate();
        game.CharacterDeactivate();
        if(game.CombatH)
            game.CombatDeactivate();
    }

    public override void CharacterMove(Hexagon h)
    {
        this.transform.position = h.transform.position + new Vector3(0, .075f, 0);
        InitialBlock.setOccupant(null);
        this.InitialBlock = h;
        h.setOccupant(this);
        this.GetComponent<BoxCollider>().enabled = true;
        game.PlayerReset();
        game.stage.Reset();
        game.InteractionDeactivate();
        game.lastAction = null;
        turn--;
        game.CharacterDeactivate();
    }
    public override void ShowMove(Hexagon h)
    {
        if (turn > 0)
        {
            this.transform.position = h.transform.position + new Vector3(0, .075f, 0);
            this.setActualBlock(h);
            game.lastAction = h;
        }
    }
}
