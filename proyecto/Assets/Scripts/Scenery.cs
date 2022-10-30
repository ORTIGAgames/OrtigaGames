using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    public Hexagon[] board;
    Manager game;
    void Awake()
    {
        board = GetComponentsInChildren<Hexagon>();
        game = GetComponentInParent<Manager>();
    }

    void Update()
    {

    }

    public Hexagon randomBlock()
    {
        return (board[Random.Range(0, board.Length)]);
    }

    public Hexagon Block(int i)
    {
        return (board[i]);
    }

    public void Reset()
    {
        foreach (Hexagon h in board)//siempre que no haya un jugador activo que ninguna ficha este marcada
        {
            h.setState(Hexagon.CodeState.Empty);
        }
        game.lastAction = null;
    }

    public void NoAttacks()
    {
        foreach (Hexagon h in board)//siempre que no haya un jugador activo que ninguna ficha este marcada
        {
            if (h.getState() == Hexagon.CodeState.Action)
                h.setState(Hexagon.CodeState.WalkableA);
        }
    }
}
