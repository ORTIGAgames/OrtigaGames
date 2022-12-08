using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    [SerializeField] protected List<Character> players = new List<Character>();
    public List<Character> allies = new List<Character>();
    [SerializeField] protected List<Character> enemies = new List<Character>();
    public List<PreTurn> preTurn = new List<PreTurn>();
    public bool allyturn;
    public Scenery stage;
    public Ally activeAlly;
    public Hexagon lastAction;
    public Character lastClicked;
    public int lose;

    #region UI
    public CombatHud CombatH;
    public GameObject InteractionH;
    public GameObject CharacterH;
    public GameObject TurnH;
    public Scenes scene;
    #endregion

    #region combat
    public Character attacker;
    public Character defender;
    #endregion

    public abstract void DeleteCharacter(Character c);
    public abstract void CombatDeactivate();
    public abstract void CombatActivation(Character c1, Character c2);
    public abstract void PlayerReset();
    public abstract void InteractionActivate();
    public abstract void InteractionDeactivate();
    public abstract void setActiveAlly(Ally a);
    public abstract void CharacterActivate(Sprite face, Sprite name, string attack, string defense, int maxHealth, string ability, string explanation, Sprite Icon);
    public abstract void CharacterDeactivate();
    public abstract void CollisionDown();
    public abstract void CollisionUp();
}
