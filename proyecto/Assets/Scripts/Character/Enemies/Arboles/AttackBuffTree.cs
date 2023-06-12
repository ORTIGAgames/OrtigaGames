using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBuffTree : MonoBehaviour
{
    public int countdown = 2;
    List<Character> enemies = new();
    [SerializeField]
    List<Hexagon> neighbours = new();
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
    public void RestarTurno()
    {
        int count = 0;
        countdown--;
        Debug.Log(countdown);
        if(countdown == 0)
        {
            foreach(Hexagon hex in neighbours)
            {
                if (hex.getOccupant() != null)
                {
                    //nada
                    if (hex.getOccupant().getSide() == "Enemy")
                    {
                        hex.getOccupant().setDamage(hex.getOccupant().getDamage() + 2);
                        feedback.GetComponent<ShowFeedback>().ShowDecission(show);
                        Debug.Log("El daño de " + hex.getOccupant().getName() + "es: " + hex.getOccupant().getDamage());
                        break;
                    }
                }
                else count++;
            }
            countdown = 2;
            if (count == neighbours.Count) this.feedback.GetComponent<ShowFeedback>().Unshow();
        }
        
    }
}
