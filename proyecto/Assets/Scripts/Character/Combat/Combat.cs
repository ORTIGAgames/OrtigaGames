using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Combat
{
    void Action(Hexagon t, int i, Character c);//indicar si puedes o no atacar al enemigo
    //bool Position(Hexagon h1, Hexagon h2, int i);//booleano para saber si estás a la distancia correcta para poder atacarlo
    void limitAction(Hexagon t, int i, Character c);
    void ValuablePosition(Hexagon h, int i);//reposicionamiento del jugador adonde pueda atacar al enemigo, desde el jugador atacado en función del estilo de combate mirar x numero de vecinos: melee = 1, range = 2 y si alguna es verde ponerla azul
    void Action(Manager m, string d);
}
