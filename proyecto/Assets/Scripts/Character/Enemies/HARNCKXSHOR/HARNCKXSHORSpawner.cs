using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HARNCKXSHORSpawner : Abilities
{
    public GameObject prefabEnemy;
    public GameObject prefabCamera;

    public override void Effect(Character c)
    {
        for (int i = 0; i <= 2; i++)
        {
            Hexagon box = this.GetComponent<Enemy>().game.stage.Block(Random.Range(0, this.GetComponent<Enemy>().game.stage.board.Length));
            while (box.getOccupant())
            {
                box = this.GetComponent<Enemy>().game.stage.Block(Random.Range(0, this.GetComponent<Enemy>().game.stage.board.Length));
            }
            GameObject enemy = Instantiate(prefabEnemy, box.transform.position + new Vector3(0, .085f, -0.05f), Quaternion.identity);
            enemy.GetComponent<Enemy>().setActualBlock(box);
            enemy.GetComponent<Enemy>().setInitialBlock(box);
            box.setOccupant(enemy.GetComponent<Character>());
            CinemachineVirtualCamera camera = Instantiate(prefabCamera.GetComponent<CinemachineVirtualCamera>());
            camera.Follow = enemy.transform;
            enemy.GetComponent<Enemy>().ncamera = camera;
            this.GetComponent<Enemy>().game.enemies.Add(enemy.GetComponent<Enemy>());
            this.GetComponent<Enemy>().game.players.Add(enemy.GetComponent<Character>());
        }
    }

    public override void BeforeTurn()
    {
        cooldown--;
    }
}