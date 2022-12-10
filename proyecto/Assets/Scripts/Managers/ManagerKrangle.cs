using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ManagerKrangle : Manager
{
    public int turnsCompleted;
    public int KrangleNumbers;
    public int turnsSpwan;
    void Start()//el manager es start mientras que el resto es awake debido a que todo tiene que estar creado antes de que el manager empiece a actuar
    {
        allyturn = true;
        Character[] StartingPlayers = GetComponentsInChildren<Character>();
        stage = GetComponentInChildren<Scenery>();

        //interface
        InteractionH = GameObject.Find("Interaction Hud");
        CombatH = GameObject.Find("Combat Hud").GetComponent<CombatHud>();
        CharacterH = GameObject.Find("Stats");
        TurnH = GameObject.Find("Turn Hud");
        ObjectiveH = GameObject.Find("Objective Hud");
        TurnH.SetActive(false);
        CharacterDeactivate();
        CombatDeactivate();
        InteractionDeactivate();

        foreach (Character c in StartingPlayers)//al iniciar la partida se le asignan a los jugadores posiciones aleatorias
        {
            players.Add(c);
            Hexagon box;
            if (c.getSide() == "Ally")
            {
                allies.Add(c);
                box = stage.Block(Random.Range(0, 6));
                while (box.getOccupant())
                {
                    box = stage.Block(Random.Range(0, 6));
                }
            }
            else
            {
                box = stage.Block(Random.Range(0, stage.board.Length));
                while (box.getOccupant() || box.transform.childCount > 0)
                {
                    box = stage.Block(Random.Range(0, stage.board.Length));
                }
                c.myAnimator.Play("Idle", -1, Random.Range(0.0f, 1.1f));
                c.myAnimator.speed = Random.Range(0.5f, 1.6f);
                enemies.Add(c);
            }
            box.setOccupant(c);
            c.transform.position = box.transform.position + new Vector3(0, .085f, -0.05f);
            c.setInitialBlock(box);
            c.setActualBlock(box);
            c.setTurn(1);
        }

        StartCoroutine(ShowMessage("Ally turn", 1.0f));
        StartCoroutine(ShowObjetive("Protect the generator 20 turns", 4.0f));
        Ally focus = (Ally)allies[Random.Range(0, allies.Count)];
        focus.Camera();
        lose = allies.Count;
        KrangleNumbers = enemies.Count;
    }
    void Update()
    {

        if (allies.Count < lose)
        {
            scene.playLose();
        }

        if (turnsCompleted == 20)
        {
            scene.playWin();
        }

        if(turnsSpwan % 2 == 0)
        {
            for(int i = 0; i < 2; i++)
            {
                Hexagon box = stage.Block(Random.Range(0, stage.board.Length));
                while (box.getOccupant() || box.transform.childCount > 0)
                {
                    box = stage.Block(Random.Range(0, stage.board.Length));
                }
                GameObject enemy = Instantiate(enemies[0].gameObject, box.transform.position + new Vector3(0, .085f, -0.05f), Quaternion.identity);
                enemy.GetComponent<Enemy>().setActualBlock(box);
                enemy.GetComponent<Enemy>().setInitialBlock(box);
                box.setOccupant(enemy.GetComponent<Character>());
                CinemachineVirtualCamera camera = Instantiate(enemies[0].GetComponent<Enemy>().ncamera);
                camera.Follow = enemy.transform;
                enemy.GetComponent<Enemy>().ncamera = camera;
                enemies.Add(enemy.GetComponent<Enemy>());
                players.Add(enemy.GetComponent<Character>());
                enemy.GetComponent<Character>().myAnimator.SetTrigger("Appear");
            }
            turnsSpwan++;
        }

        if (allyturn && CheckTurn(allies))
        {
            PlayerReset();
            stage.Reset();
            StartCoroutine(ShowMessage("Enemy Turn", 1.0f));
            allyturn = false;
            foreach (PreTurn p in preTurn.ToArray())
                p.BeforeTurn();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].setTurn(1);
                print(enemies[i]);
                print(enemies[i].GetComponent<Enemy>().ncamera.Follow);
                StartCoroutine(CameraFocus(0.5f * (i + 1), (Enemy)enemies[i]));
            }
            turnsCompleted++;
        }

        if (!allyturn && CheckTurn(enemies))
        {
            PlayerReset();
            stage.Reset();
            StartCoroutine(ShowMessage("Ally turn", 1.0f));
            StartCoroutine(ShowObjetive(" turns left", 4.05f));
            allyturn = true;
            foreach (PreTurn p in preTurn.ToArray())
                p.BeforeTurn();
            foreach (Ally a in allies)
            {
                a.setTurn(1);
            }
            Ally focus = (Ally)allies[Random.Range(0, allies.Count)];
            focus.Camera();
            turnsSpwan++;
        }
    }

    public bool CheckTurn(List<Character> listc)
    {
        foreach (Character c in listc)
        {
            if (c.getTurn() > 0)
                return false;
        }
        return true;
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        TurnH.SetActive(true);
        TextMeshProUGUI Turn = GameObject.Find("Turn").GetComponent<TextMeshProUGUI>();
        Turn.text = message;
        yield return new WaitForSeconds(delay);
        TurnH.SetActive(false);
    }

    IEnumerator ShowObjetive(string message, float delay)
    {
        ObjectiveH.SetActive(true);
        TextMeshProUGUI Turn = GameObject.Find("Objective").GetComponent<TextMeshProUGUI>();
        if(delay == 4.05f)
        {
            Turn.text = (20 - turnsCompleted) + message;
        }
        else Turn.text = message; 
        yield return new WaitForSeconds(delay);
        ObjectiveH.SetActive(false);
    }

    IEnumerator CameraFocus(float timer, Enemy e)
    {
        yield return new WaitForSeconds(timer);
        e.Camera();
        StartCoroutine(Movement(0.5f, e));
    }
    IEnumerator Movement(float timer, Enemy e)
    {
        yield return new WaitForSeconds(timer);
        //e.CharacterMove(e.getInitialBlock().randomNeighbour());
        e.EB.EnemyControl();
    }

    public override void CombatActivation(Character Figther1, Character Figther2)
    {
        if (Figther1.getTurn() > 0)
        {
            //preparations
            attacker = Figther1;
            defender = Figther2;
            stage.Reset();
            if (Figther1.GetComponent<Abilities>())
                CombatActivate(Figther1.GetComponent<Abilities>().ActiveIcon);
        }
    }

    public override void PlayerReset()
    {
        foreach (Character c in players)
            c.setTarget(false);
        lastClicked = null;
        activeAlly = null;
        attacker = null;
        defender = null;
    }

    public override void DeleteCharacter(Character c)
    {
        if (c.getSide() == "Ally")
            allies.Remove((Ally)c);
        else
            enemies.Remove((Enemy)c);
        players.Remove(c);
        Destroy(c.gameObject);
    }

    public override void CollisionUp()
    {
        foreach (Character c in players)
            c.GetComponent<BoxCollider>().enabled = true;

    }

    public override void CollisionDown()
    {
        foreach (Character c in players)
            c.GetComponent<BoxCollider>().enabled = false;
    }


    #region interface
    public override void CharacterActivate(Sprite face, Sprite name, string attack, string defense, int maxHealth, string ability, string explanation, Sprite Icon)
    {
        CharacterH.SetActive(true);
        GameObject.Find("Face").GetComponent<Image>().sprite = face;
        GameObject.Find("Name").GetComponent<Image>().sprite = name;
        GameObject.Find("AttackValue").GetComponentInChildren<TextMeshProUGUI>().SetText(attack);
        GameObject.Find("DefenseValue").GetComponentInChildren<TextMeshProUGUI>().SetText(defense);
        HealthBar bar = GetComponentInChildren<HealthBar>();
        bar.SetMaxHealth(maxHealth);
        bar.character = activeAlly;
        GameObject.Find("Ability").GetComponent<AbilityController>().Ability.GetComponentInChildren<TextMeshProUGUI>().SetText(explanation);
        GameObject.Find("Ability").GetComponent<AbilityController>().Ability.SetActive(false);
        CharacterH.GetComponent<StatsHud>().Ability.GetComponent<Image>().sprite = Icon;
        if (activeAlly.GetComponent<Abilities>().Role == "SelfSupport")
        {
            attacker = activeAlly;
            CharacterH.GetComponent<StatsHud>().Ability.GetComponent<AbilityController>().AbilityCaller.gameObject.SetActive(true);
            CharacterH.GetComponent<StatsHud>().Ability.GetComponent<AbilityController>().AbilityCaller.GetComponent<Image>().sprite = attacker.GetComponent<Abilities>().ActiveIcon;
            if (attacker.GetComponent<Abilities>().cooldown > 0) CharacterH.GetComponent<StatsHud>().Ability.GetComponent<AbilityController>().AbilityCaller.interactable = false;
            else CharacterH.GetComponent<StatsHud>().Ability.GetComponent<AbilityController>().AbilityCaller.interactable = true;
        }
        else
            CharacterH.GetComponent<StatsHud>().Ability.GetComponent<AbilityController>().AbilityCaller.gameObject.SetActive(false);
    }

    public override void CharacterDeactivate()
    {
        CharacterH.SetActive(false);
    }
    public override void InteractionActivate()
    {
        InteractionH.SetActive(true);
    }

    public override void InteractionDeactivate()
    {
        InteractionH.SetActive(false);
    }

    public void CombatActivate(Sprite Image)
    {
        if (attacker.GetComponent<Abilities>().cooldown > 0) CombatH.Ability.interactable = false;
        else CombatH.Ability.interactable = true;
        CollisionDown();
        if (Image)//cambiar cuando todos tengan habilidad
        {
            CombatH.Ability.GetComponent<Image>().sprite = Image;
        }
        CombatH.gameObject.SetActive(true);
        if (attacker.getSide() == defender.getSide())
        {
            CombatH.Ability.gameObject.SetActive(true);
            CombatH.Action.gameObject.SetActive(false);
        }
        else
        {
            if (attacker.GetComponent<Abilities>().Role == "Support")
            {
                CombatH.Ability.gameObject.SetActive(false);
                CombatH.Action.gameObject.SetActive(true);
            }
            else
            {
                CombatH.Ability.gameObject.SetActive(true);
                CombatH.Action.gameObject.SetActive(true);
            }
        }
    }

    public override void CombatDeactivate()
    {
        CollisionUp();
        CombatH.gameObject.SetActive(false);
        stage.Reset();
    }

    #endregion
    public override void setActiveAlly(Ally a)
    {
        activeAlly = a;
    }
}
