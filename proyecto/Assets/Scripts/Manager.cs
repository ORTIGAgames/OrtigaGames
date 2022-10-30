using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    [SerializeField] List<Character> players = new List<Character>();
    public List<Character> allies = new List<Character>();
    [SerializeField] List<Character> enemies = new List<Character>();
    public bool allyturn;
    public Scenery stage;
    public Character activeAlly;
    public Character activeEnemy;
    public Hexagon lastAction;

    #region UI
    public GameObject CombatH;
    public GameObject InteractionH;
    public GameObject CharacterH;
    public GameObject TurnH;
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
        CharacterH = GameObject.Find("Stats");
        TurnH = GameObject.Find("Turn Hud");
        TurnH.SetActive(false);
        CharacterDeactivate();
        CombatDeactivate();
        InteractionDeactivate();

        foreach (Character c in StartingPlayers)//al iniciar la partida se le asignan a los jugadores posiciones aleatorias
        {
            players.Add(c);
            if (c.getSide() == "Ally")
            {
                allies.Add(c);
                c.setTurn(1);
            }
            else
                enemies.Add(c);
            Hexagon box = stage.randomBlock();
            while (box.getOccupant())
            {
                box = stage.randomBlock();
            }
            box.setOccupant(c);
            c.transform.position = box.transform.position + new Vector3(0, .075f, 0);
            c.setInitialBlock(box);
            StartCoroutine(ShowMessage("Ally turn", 1.0f));
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
            StartCoroutine(ShowMessage("Enemy Turn", 1.0f));
            allyturn = false;
            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i].setTurn(1);
                StartCoroutine(Movement(2.0f * (i + 1), (Enemy)enemies[i]));
            }
        }

        if (!allyturn && CheckTurn(enemies))
        {
            StartCoroutine(ShowMessage("Ally turn", 1.0f)); 
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
    IEnumerator ShowMessage(string message, float delay)
    {
        TurnH.SetActive(true);
        TextMeshProUGUI Turn = GameObject.Find("Turn").GetComponent<TextMeshProUGUI>();
        Turn.text = message;      
        yield return new WaitForSeconds(delay);
        TurnH.SetActive(false);
    }
    IEnumerator Movement(float timer, Enemy e)
    {
        yield return new WaitForSeconds(timer);
        e.CharacterMove(e.getInitialBlock().randomNeighbour());
    }
    public void CombatActivation(Character Figther1, Character Figther2)
    {
        if (Figther1.getTurn() > 0)
        {
            //preparations
            attacker = Figther1;
            defender = Figther2;
            stage.Reset();
            CombatActivate();
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
        HealthBar bar = GetComponentInChildren<HealthBar>();
        bar.SetMaxHealth(maxHealth);
        bar.character = activeAlly;
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

    #endregion
    public void setActiveAlly(Character a)
    {
        activeAlly = a;
    }

}
