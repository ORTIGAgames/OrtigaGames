using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;


public class KrangleTreeBehaviour : MonoBehaviour
{
    public Manager Game;
    bool allies = false;
    public Image action;
    public Sprite[] differentActions;
    int election;
    public GameObject generate;

    private void Awake()
    {
        Game = GameObject.Find("Manager").GetComponent<Manager>();
    }
    public void DecissionShow()
    {
        if(this.GetComponent<Crew>().leader == true)//si se es el líder se hará unas cosas si no, otras
        {
            if(this.GetComponent<Crew>().target == null)//comprueba si hay un objetivo al que hacer focus
            {
                action.GetComponent<ShowFeedback>().ShowDecission(differentActions[0]);
                election = 0;
            }
            else//si ya hay un objetivo se centrará en hacer otras cosas
            {
                
                Game.PlayerReset();
                this.GetComponent<DmgStyle>().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
                foreach(Enemy e in Game.enemies)//comprobará si hay aliados cerca, si los hay los buffará
                {
                    if (e.getActualBlock().getState() == Hexagon.CodeState.AllyT && e.GetComponent<Crew>().leader == false && e.GetComponent<Crew>().following == this.GetComponent<Enemy>())
                    {
                        allies = true;
                        break;
                    }
                }
                Game.stage.Reset();
                if (allies == false)
                {
                    action.GetComponent<ShowFeedback>().ShowDecission(differentActions[2]);
                    election = 2;
                }
                else
                {
                    action.GetComponent<ShowFeedback>().ShowDecission(differentActions[1]);
                    election = 1;
                }
                allies = false;
            }
        }
        else
        {
            if (this.GetComponent<Crew>().following == null)//primero compruebe si el krangle tiene líder, por si algún aliado lo ha matado
            {
                action.GetComponent<ShowFeedback>().ShowDecission(differentActions[3]);
                election = 3;
            }
            else
            {
                if (this.GetComponent<Enemy>().getHealth() < (this.GetComponent<Enemy>().MaxHealth / 2))//luego comprobará si tiene menos de 50% de vida
                {
                    if (Random.Range(0, 2) % 2 == 0)
                    {
                        action.GetComponent<ShowFeedback>().ShowDecission(differentActions[4]);
                        election = 4;
                    }
                }
                else
                {
                    Game.PlayerReset();
                    this.GetComponent<DmgStyle>().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
                    if (this.GetComponent<Crew>().target.getTarget() == true)//si está a rango del target
                    {
                        action.GetComponent<ShowFeedback>().ShowDecission(differentActions[5]);
                        election = 5;
                    }
                    else
                    {
                        action.GetComponent<ShowFeedback>().ShowDecission(differentActions[6]);
                        election = 6;
                    }
                }
            }     
        }
        StartCoroutine(DecissionMake(election));
        StartCoroutine(Wait());
    }

    IEnumerator DecissionMake(int e)
    {
        yield return new WaitForSeconds(2f);
        switch (e)
        {
            case 0:
                this.GetComponent<Crew>().focusEnemy();
                break;
            case 1:
                this.GetComponent<DmgStyle>().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());
                foreach (Enemy en in Game.enemies)//comprobará si hay aliados cerca, si los hay los buffará
                {
                    if (en.getActualBlock().getState() == Hexagon.CodeState.AllyT && en.GetComponent<Crew>().leader == false && en.GetComponent<Crew>().following == this.GetComponent<Enemy>())
                    {
                        this.GetComponent<Ability>().Execution(en);
                        break;
                    }
                }
                Game.PlayerReset();
                break;
            case 2:
                //si no hay aliados cerca los llamará
                Hexagon box = Game.stage.Block(Random.Range(0, Game.stage.board.Length));//Spawn del Krangle
                while (box.getOccupant() || box.transform.childCount > 0)
                {
                    box = Game.stage.Block(Random.Range(0, Game.stage.board.Length));
                }
                GameObject enemy = Instantiate(generate, box.transform.position + new Vector3(0, .085f, -0.05f), Quaternion.identity);
                enemy.GetComponent<Enemy>().setActualBlock(box);
                enemy.GetComponent<Enemy>().setInitialBlock(box);
                enemy.GetComponent<Enemy>().setTurn(0);
                box.setOccupant(enemy.GetComponent<Character>());
                enemy.GetComponent<Crew>().leader = false;
                enemy.GetComponent<Crew>().followLeader();
                CinemachineVirtualCamera camera = Instantiate(Game.enemies[0].GetComponent<Enemy>().ncamera);
                camera.transform.parent = GameObject.Find("Cameras").transform;
                camera.Follow = enemy.transform;
                enemy.GetComponent<Enemy>().ncamera = camera;
                Game.enemies.Add(enemy.GetComponent<Enemy>());
                Game.players.Add(enemy.GetComponent<Character>());
                enemy.GetComponent<Character>().myAnimator.SetTrigger("Appear");
                Game.PlayerReset();
                break;
            case 3:
                this.GetComponent<Crew>().followLeader();//si no tiene querrá seguir a uno nuevo
                break;
            case 4:
                this.GetComponent<DmgStyle>().Action(this.GetComponent<Enemy>().getActualBlock(), 0, this.GetComponent<Enemy>());//si no tiene más del 50% de vida podrá cabrearse y quere atacar a su líder
                Enemy attacked = new Enemy();
                foreach (Enemy en in Game.enemies)
                {
                    if (en.getActualBlock().getState() == Hexagon.CodeState.AllyT)
                    {
                        attacked = en;
                        if (en.GetComponent<Crew>().leader == true) break;//una vez encuentre a un leader lo atacará
                    }
                }
                this.GetComponent<Enemy>().game.CombatActivation(this.GetComponent<Enemy>(), attacked);//le ataca
                this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().game, "Action");
                Game.stage.Reset();
                break;
            case 5:
                Game.stage.Reset();
                this.GetComponent<Enemy>().game.CombatActivation(this.GetComponent<Enemy>(), this.GetComponent<Crew>().target);//le ataca, se puede pensar en poner algo más complejo otro sistema de utilidad para hacer habilidades o ataque.
                this.GetComponent<Enemy>().getStyle().Action(this.GetComponent<Enemy>().game, "Action");
                Game.stage.Reset();
                break;
            case 6:
                Game.stage.Reset();
                this.GetComponent<Enemy>().Move(this.GetComponent<Enemy>().getInitialBlock(), 0);
                Hexagon Walkto = null;
                float valueN = 999999;
                foreach (Hexagon hex in Game.stage.board)//buscan la casilla más óptima a la que desplazarse del target que tengan
                {
                    if (hex.getState() == Hexagon.CodeState.WalkableE)
                    {
                        float auxN = 0;
                        float dx = this.GetComponent<Crew>().target.getInitialBlock().dx - hex.dx;
                        float dy = this.GetComponent<Crew>().target.getInitialBlock().dy - hex.dy;
                        if (System.Math.Sign(dx) == System.Math.Sign(dy)) auxN = System.Math.Abs(dx + dy);
                        else auxN = System.Math.Max(System.Math.Abs(dx), System.Math.Abs(dy));
                        if (auxN < valueN && hex.getOccupant() == null && (hex.transform.childCount <= 0 || (hex.transform.GetChild(0).name != "Obstacle" && hex.transform.GetChild(0).name != "Obstacle2")))
                        {
                            Walkto = hex;
                            valueN = auxN;
                        }
                    }
                }
                Game.stage.Reset();
                this.GetComponent<Enemy>().CharacterMove(Walkto, false);
                break;
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        this.action.GetComponent<ShowFeedback>().Unshow();
        this.GetComponent<Enemy>().EndTurn();
    }
}
