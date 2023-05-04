using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    public Manager Game;
    public bool leader;
    public Enemy following;
    public Ally target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void followLeader()
    {
        following = (Enemy)Game.enemies[0];//ponemos de dummy para hacer comparaciones de distancia
        foreach(Enemy e in Game.enemies)
        {
            if(e.GetComponent<Crew>().leader == true)
            {

            }
        }
    }

    public void focusEnemy()
    {
        target = (Ally)Game.allies[0];//ponemos de dummy para hacer comprobaciones de distancia
        foreach(Ally a in Game.allies)
        {
            
        }
    }
}
