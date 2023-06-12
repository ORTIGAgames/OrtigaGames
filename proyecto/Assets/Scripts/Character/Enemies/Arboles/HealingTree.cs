using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealingTree : MonoBehaviour
{
    public float random;
    public List<Character> enemies = new();
    [SerializeField]
    List<Hexagon> neihbourgs = new();
    public Hexagon hexagon;
    public Image feedback;
    public Sprite show;

    // Start is called before the first frame update
    void Start()
    {
       
        enemies = GameObject.Find("Manager").GetComponent<Manager>().enemies;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanHeal()
    {
        
        random = Random.Range(0, 100);
        //if (random < 25) 
        Heal();
        
    }
    public void Heal()
    {
        foreach(Hexagon g in neihbourgs)
        {
            if(g.getOccupant() != null)
            {
                //nada
                if (g.getOccupant().getSide() == "Enemy")
                {
                    print("si");
                    g.getOccupant().setHealth(g.getOccupant().getHealth() + 2);
                    feedback.GetComponent<ShowFeedback>().ShowDecission(show);
                }
            }
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        this.feedback.GetComponent<ShowFeedback>().Unshow();
        this.GetComponent<Enemy>().EndTurn();
    }
}
