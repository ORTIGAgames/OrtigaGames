using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuffTree : MonoBehaviour
{
    int countdown = 5;
    List<Character> enemies = new();
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
        //CallHimenopios{
        countdown = 5;
    }
    public void CallHimenopios()
    {
        foreach(Character e in enemies)
        {

        }
    }
}
