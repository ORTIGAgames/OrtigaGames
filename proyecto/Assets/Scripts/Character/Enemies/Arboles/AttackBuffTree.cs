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
                        StartCoroutine(Wait());
                        Debug.Log("El da�o de " + hex.getOccupant().getName() + "es: " + hex.getOccupant().getDamage());
                        break;
                    }
                }
            }
            countdown = 2;
        }
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        this.feedback.GetComponent<ShowFeedback>().Unshow();
        this.GetComponent<Enemy>().EndTurn();
    }
}
