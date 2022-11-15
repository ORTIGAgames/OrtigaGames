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
    public List<PreTurn> preTurn = new List<PreTurn>();
    public bool allyturn;
    public Scenery stage;
    public Ally activeAlly;
    public Hexagon lastAction;
    public Character lastClicked;

    #region UI
    public CombatHud CombatH;
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
        CombatH = GameObject.Find("Combat Hud").GetComponent<CombatHud>();
        CharacterH = GameObject.Find("Stats");
        TurnH = GameObject.Find("Turn Hud");
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
                box = stage.Block(Random.Range(38, 44));
                while (box.getOccupant())
                {
                    box = stage.Block(Random.Range(38, 44));
                }
                enemies.Add(c);
            }
            box.setOccupant(c);
            c.transform.position = box.transform.position + new Vector3(0, .085f, 0);
            c.setInitialBlock(box);
            c.setTurn(1);
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
            PlayerReset();
            stage.Reset();
            StartCoroutine(ShowMessage("Enemy Turn", 1.0f));
            allyturn = false;
            foreach (PreTurn p in preTurn)
                p.BeforeTurn();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].setTurn(1);
                StartCoroutine(Movement(2.0f * (i + 1), (Enemy)enemies[i]));
            }
        }

        if (!allyturn && CheckTurn(enemies))
        {
            PlayerReset();
            stage.Reset();
            StartCoroutine(ShowMessage("Ally turn", 1.0f)); 
            allyturn = true;
            foreach (PreTurn p in preTurn)
                p.BeforeTurn();
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
        //e.CharacterMove(e.getInitialBlock().randomNeighbour());
        e.EnemyControl();
    }
    public void CombatActivation(Character Figther1, Character Figther2)
    {
        if (Figther1.getTurn() > 0)
        {
            //preparations
            attacker = Figther1;
            defender = Figther2;
            stage.Reset();
            if(Figther1.GetComponent<Abilities>())
                CombatActivate(Figther1.GetComponent<Abilities>().Name);
            else
                CombatActivate("No abilities");
        }
    }

    public void PlayerReset()
    {
        foreach (Character c in players)
        {
            c.setTarget(false);
        }
        lastClicked = null;
        activeAlly = null;
        attacker = null;
        defender = null;
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
    public void CharacterActivate(Sprite face, string name, string attack, string defense, string velocity, int health, int maxHealth, string ability, string explanation)
    {
        CharacterH.SetActive(true);
        GameObject.Find("Face").GetComponent<Image>().sprite = face;
        GameObject.Find("Name").GetComponentInChildren<TextMeshProUGUI>().SetText(name);
        GameObject.Find("AttackValue").GetComponentInChildren<TextMeshProUGUI>().SetText(attack); ;
        GameObject.Find("DefenseValue").GetComponentInChildren<TextMeshProUGUI>().SetText(defense);
        HealthBar bar = GetComponentInChildren<HealthBar>();
        bar.SetMaxHealth(maxHealth);
        bar.character = activeAlly;
        GameObject.Find("Ability").GetComponent<TextMeshProUGUI>().SetText(ability);
        GameObject.Find("Ability").GetComponent<AbilityController>().Ability.GetComponentInChildren<TextMeshProUGUI>().SetText(explanation);
        GameObject.Find("Ability").GetComponent<AbilityController>().Ability.SetActive(false);
        if(activeAlly.GetComponent<Abilities>().Role == "SelfSupport")
        {
            attacker = activeAlly;
            CharacterH.GetComponent<StatsHud>().Ability.SetActive(true);
        }
        else
            CharacterH.GetComponent<StatsHud>().Ability.SetActive(false);
    }

    public void CharacterDeactivate()
    {
        CharacterH.GetComponent<StatsHud>().Ability.SetActive(false);
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

    public void CombatActivate(string an)
    {
        CombatH.Ability.GetComponentInChildren<TextMeshProUGUI>().SetText(an);
        CombatH.gameObject.SetActive(true);
        if (attacker.getSide() == defender.getSide())
            CombatH.Action.SetActive(false);
        else
            CombatH.Action.SetActive(true);
    }

    public void CombatDeactivate()
    {
        CombatH.gameObject.SetActive(false);
        stage.Reset();
    }

    #endregion
    public void setActiveAlly(Ally a)
    {
        activeAlly = a;
    }

}
