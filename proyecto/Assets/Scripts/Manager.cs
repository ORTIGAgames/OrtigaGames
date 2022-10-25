using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    [SerializeField] List<Character> players = new List<Character>();
    [SerializeField] List<Character> allies = new List<Character>();
    [SerializeField] List<Character> enemies = new List<Character>();
    public bool allyturn;
    public Scenery stage;
    public Character activeAlly;
    public Character activeEnemy;
    public Hexagon lastAction;

    #region UI
    public GameObject CombatH;
    public GameObject SceneryH;
    public GameObject InteractionH;
    public GameObject CharacterH;
    #endregion

    #region combat
    public Character attacker;
    public Character defender;
    #endregion

    void Start()//el manager es start mientras que el resto es awake debido a que todo tiene que estar creado antes de que el manager empiece a actuar
    {
        allyturn = true;
        Character[] StartingPlayers = GetComponentsInChildren<Character>();
        stage = GetComponentInChildren<Scenery>();

        //interface
        InteractionH = GameObject.Find("Interaction Hud");
        CombatH = GameObject.Find("Combat Hud");
        SceneryH = GameObject.Find("Scenery Hud");
        CharacterH = GameObject.Find("Stats");
        CharacterDeactivate();
        CombatDeactivate();
        InteractionDeactivate();

        foreach (Character c in StartingPlayers)//al iniciar la partida se le asignan a los jugadores posiciones aleatorias
        {
            players.Add(c);
            if (c.getSide() == "Ally")
            {
                allies.Add(c);
                c.setTurn(300);
            }
            else
                enemies.Add(c);
            Hexagon box = stage.randomBlock();
            while (box.getOccupant())
            {
                box = stage.randomBlock();
            }
            box.setOccupant(c);
            c.transform.position = box.transform.position + new Vector3(0, .05f, 0);
            c.setInitialBlock(box);
        }
    }
    void Update()
    {
        if (allies.Count <= 0)
        {
            SceneManager.LoadScene(2);
        }

        if (enemies.Count <= 0)
        {
            SceneManager.LoadScene(1);
        }

        if (allyturn && CheckTurn(allies))
        {
            allyturn = false;
            foreach (Enemy e in enemies)
            {
                e.setTurn(1);
            }
        }

        if (!allyturn && CheckTurn(enemies))
        {
            allyturn = true;
            foreach (Ally a in allies)
            {
                a.setTurn(1);
            }
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
    public void CombatActivation(Character Figther1, Character Figther2)
    {
        if (Figther1.getTurn() > 0)
        {
            //preparations
            activeAlly = null;
            activeEnemy = null;
            attacker = Figther1;
            defender = Figther2;
            attacker.CharacterMove(attacker.getActualBlock());
            stage.Reset();
            InteractionDeactivate();
            SceneryDeactivate();
            Figther1.healthBar.gameObject.SetActive(true);
            Figther2.healthBar.gameObject.SetActive(true);
            CombatActivate();
            Figther1.setTurn(Figther1.getTurn() - 1);
        }
    }

    public void PlayerReset()
    {
        foreach (Character c in players)
        {
            c.setTarget(false);
        }
        activeEnemy = null;
        activeAlly = null;
    }

    public void DeleteCharacter(Character c)
    {
        if (c.getSide() == "Ally")
            allies.Remove((Ally)c);
        else
            enemies.Remove((Enemy)c);
        players.Remove(c);
        Destroy(c.gameObject);
    }

    #region interface
    public void CharacterActivate(Sprite face, string name, string attack, string defense, string velocity, int health, int maxHealth)
    {
        CharacterH.SetActive(true);
        Image characterf = GameObject.Find("Face").GetComponent<Image>();
        characterf.sprite = face;
        TextMeshProUGUI charactern = GameObject.Find("Name").GetComponentInChildren<TextMeshProUGUI>();
        charactern.SetText(name);
        TextMeshProUGUI charactera = GameObject.Find("AttackValue").GetComponentInChildren<TextMeshProUGUI>();
        charactera.SetText(attack);
        TextMeshProUGUI characterd = GameObject.Find("DefenseValue").GetComponentInChildren<TextMeshProUGUI>();
        characterd.SetText(defense);
        TextMeshProUGUI characterv = GameObject.Find("VelocityValue").GetComponentInChildren<TextMeshProUGUI>();
        characterv.SetText(velocity);
        HealthBar bar = GetComponentInChildren<HealthBar>();
        bar.SetMaxHealth(maxHealth);
        bar.setHealth(health);
    }

    public void CharacterDeactivate()
    {
        CharacterH.SetActive(false);
    }
    public void InteractionActivate()
    {
        InteractionH.SetActive(true);
    }

    public void InteractionDeactivate()
    {
        InteractionH.SetActive(false);
    }

    public void CombatActivate()
    {
        CombatH.SetActive(true);
    }

    public void CombatDeactivate()
    {
        CombatH.SetActive(false);
        stage.Reset();
    }

    public void SceneryActivate()
    {
        SceneryH.SetActive(true);
    }

    public void SceneryDeactivate()
    {
        SceneryH.SetActive(false);
    }

    #endregion
    public void setActiveAlly(Character a)
    {
        activeAlly = a;
    }

}
