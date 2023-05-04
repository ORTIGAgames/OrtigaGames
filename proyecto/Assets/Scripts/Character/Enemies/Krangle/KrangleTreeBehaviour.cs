using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KrangleTreeBehaviour : MonoBehaviour
{
    public Manager Game;
    public void Decission()
    {
        if(this.GetComponent<Crew>().leader == true)
        {
            if(this.GetComponent<Crew>().target == null)//comprueba si hay un objetivo al que hacer focus
            {
                this.GetComponent<Crew>().focusEnemy();
            }
            else//si ya hay un objetivo se centrará en hacer otras cosas
            {
                this.GetComponent<DmgStyle>().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
                foreach(Enemy e in Game.enemies)//comprobará si hay aliados cerca, si los hay los buffará
                {
                    if (e.getTarget() == true)
                    {
                        this.GetComponent<Ability>().Execution(e);
                    }
                }
                //si no hay aliados cerca generará
                Hexagon box = Game.stage.Block(Random.Range(0, Game.stage.board.Length));//Spawn del Krangle
                while (box.getOccupant() || box.transform.childCount > 0)
                {
                    box = Game.stage.Block(Random.Range(0, Game.stage.board.Length));
                }
                GameObject enemy = Instantiate(Game.enemies[0].gameObject, box.transform.position + new Vector3(0, .085f, -0.05f), Quaternion.identity);
                enemy.GetComponent<Crew>().leader = false;
                enemy.GetComponent<Crew>().followLeader();
                enemy.GetComponent<Enemy>().setActualBlock(box);
                enemy.GetComponent<Enemy>().setInitialBlock(box);
                box.setOccupant(enemy.GetComponent<Character>());
                CinemachineVirtualCamera camera = Instantiate(Game.enemies[0].GetComponent<Enemy>().ncamera);
                camera.Follow = enemy.transform;
                enemy.GetComponent<Enemy>().ncamera = camera;
                Game.enemies.Add(enemy.GetComponent<Enemy>());
                Game.players.Add(enemy.GetComponent<Character>());
                enemy.GetComponent<Character>().myAnimator.SetTrigger("Appear");
            }
        }
        if(this.GetComponent<Crew>().following == null)//un arbol que primero compruebe si el krangle tiene líder, por si algún aliado lo ha matado
        {
            this.GetComponent<Crew>().followLeader();//si no tiene querrá seguir a uno nuevo
        }
        if(this.GetComponent<Enemy>().getHealth() < this.GetComponent<Enemy>().getHealth() / 2)//luego comprobará si tiene menos de 50% de vida
        {
            //si no tiene más del 50% de vida podrá cabrearse y quere atacar a su líder
        }
    }
}
