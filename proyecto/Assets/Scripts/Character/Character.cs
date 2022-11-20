using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public int MaxHealth;
    [SerializeField]  protected int Health;
    [SerializeField]  protected int Damage;
    [SerializeField]  protected int Defense;
    [SerializeField]  protected int Speed;
    [SerializeField]  protected string Name;
    [SerializeField]  protected int turn;
    protected Abilities Abilities;
    public Manager game;
    protected string side;
    protected bool Action;
    protected bool PositionChange;
    public enum Movement { Short, Medium, Large };
    [SerializeField] protected Movement displacement;
    [SerializeField] protected Hexagon InitialBlock;
    [SerializeField] protected Hexagon ActualBlock;
    [SerializeField] protected Combat style;
    [SerializeField] protected bool targetable;
    [SerializeField] protected Sprite Face;
    //[SerializeField] Movement displacement; posible uso en mejoras para diferentes movimientos variados
    public HealthBar healthBar;
    public Animator myAnimator;
    public Sprite NameIcon;


    public virtual void Awake()
    {
        Abilities = GetComponent<Abilities>();
        game = GetComponentInParent<Manager>();
        style = GetComponent<Combat>();
        targetable = false;
        
        //displacement = GetComponent<Movement>();//uso de la clase movement en un futuro si hay posiblidad para movimientos especiales
    }

    public abstract void OnMouseDown();
    public abstract void CharacterMove(Hexagon h);
    public abstract void Move(Hexagon t, int i);//Manera mas simple de implementar movimiento con uno de casillas individuales que avanza en bucle según un determinado enumerador
    public abstract void ShowMove(Hexagon h);
    public abstract void Cancel();

    #region getters setter
    public virtual void setTurn(int t)
    {
        turn = t;
    }

    public virtual int getTurn()
    {
        return turn;
    }
    public virtual void setInitialBlock(Hexagon a)
    {
        InitialBlock = a;
    }

    public virtual Hexagon getInitialBlock()
    {
        return InitialBlock;
    }
    public virtual void setActualBlock(Hexagon a)
    {
        ActualBlock = a;
    }

    public virtual Hexagon getActualBlock()
    {
        return ActualBlock;
    }

    public virtual Movement getMovement()
    {
        return displacement;
    }

    public virtual void setMovement(Movement m)
    {
        displacement = m;
    }

    public virtual bool getTarget()
    {
        return targetable;
    }

    public virtual void setTarget(bool b)
    {
        targetable = b;
    }

    public virtual Combat getStyle()
    {
        return style;
    }

    public virtual void setStyle(Combat c)
    {
        style = c;
    }
    public virtual string getSide()
    {
        return side;
    }

    public virtual void setFace(Sprite c)
    {
        Face = c;
    }
    public virtual Sprite getFace()
    {
        return Face;
    }

    public virtual string getName()
    {
        return Name;
    }

    #region Stats

    public virtual int getHealth()
    {
        return Health;
    }

    public virtual void setHealth(int h)
    {
        if (h <= MaxHealth)
            Health = h;
        if (Health <= 0)
            game.DeleteCharacter(this);      
    }

    public virtual int getDamage()
    {
        return Damage;
    }

    public virtual void setDamage(int d)
    {
        Damage = d;
    }

    public virtual int getSpeed()
    {
        return Speed;
    }

    public virtual void setSpeed(int s)
    {
        Speed = s;
    }

    public virtual int getDefense()
    {
        return Defense;
    }

    public virtual void setDefense(int d)
    {
        Defense = d;
    }

    #endregion

    public virtual Abilities getAbilities()
    {
        return Abilities;
    }

    #endregion

}