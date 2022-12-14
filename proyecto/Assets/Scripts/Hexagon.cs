using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public int dx = 0;
    public int dy = 0;

    public List<Hexagon> neighbours = new List<Hexagon>();
    [SerializeField] Character occupant;

    
    public enum CodeState { Empty, WalkableA, WalkableE, EnemyT, AllyT, Action }
    [SerializeField] CodeState state;
    public Renderer VisualState;
    Manager game;


    void Awake()
    {
        game = GetComponentInParent<Manager>();
        occupant = null;
        VisualState = GetComponent<Renderer>();
        state = CodeState.Empty;
    }

    private void OnMouseDown()
    {
        if (game.activeAlly)
        {
            if (this.state == CodeState.Action || this.state == CodeState.WalkableA)//si el jugador esta activo y la casilla a la que quiere ir es verde se podr? mover a dicha casilla primero se le mostrara la posicion y con doble click se movera definitivamente
            {
                if (game.lastAction == this)
                {
                    FindObjectOfType<AudioManager>().Play("Move");
                    game.activeAlly.CharacterMove(this, false);
                }
                else
                {                    
                    game.activeAlly.ShowMove(this);
                }
            }
        }
    }

    public Hexagon randomNeighbour()
    {
        int counter = 0;
        Hexagon neighbour;
        do
        {
            counter++;
            if(counter == 7)
            {
                return this;
            }
            neighbour = neighbours[Random.Range(0, neighbours.Count)];
        } while (neighbour == null || neighbour.getOccupant());

        return (neighbour);
    }

    public Character getOccupant()
    {
        return occupant;
    }

    public void setOccupant(Character c)
    {
        occupant = c;
    }

    public CodeState getState()
    {
        return state;
    }

    public void setState(CodeState c)
    {
        state = c;
        switch (c)
        {
            case CodeState.Empty:
                this.VisualState.material.color = Color.white;
                break;
            case CodeState.WalkableA:
                this.VisualState.material.color = Color.green;
                break;
            case CodeState.WalkableE:
                this.VisualState.material.color = Color.gray;
                break;
            case CodeState.EnemyT:
                this.VisualState.material.color = Color.red;
                occupant.setTarget(true);
                break;
            case CodeState.AllyT:
                this.VisualState.material.color = Color.yellow;
                occupant.setTarget(true);
                break;
            case CodeState.Action:
                this.VisualState.material.color = Color.blue;
                break;
        }
    }
}