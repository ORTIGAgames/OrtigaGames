using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenesControler : MonoBehaviour
{
    public static int[,] characters = new int[6, 3] { { 24, 4, 5 }, { 24, 5, 4 }, { 26, 2, 4}, { 30, 3, 7 }, { 20, 5, 4 }, { 20, 7, 2 } };
    public static int upgradePiont = 0;
    public static string[] names = new string[6] { "Declan", "Winnie", "G470", "NASS", "Norbert", "Caroline" };
    public static string[] namesEnemies = new string[6] { "Himenopio F", "Himenopio M", "Krandle", "Parasito", "HARNCKXSHOR", "Minion" };
    public static string[,] backgrounds = new string[3,6] { { "Declan", "Winnie", "G470", "Nass", "Norbert", "Caroline" }, { "a", "b", "c", "d", "e", "f" }, { "1", "2", "3", "4", "5", "6" } }; //En orden, backgrounds, descripcion y estilo de combate
    public static string[,] backgroundsEnemies = new string[3,6] { { "Declan", "Winnie", "G470", "Nass", "Norbert", "Caroline" }, { "a", "b", "c", "d", "e", "f" }, { "1", "2", "3", "4", "5", "6" } };
    public static string[] levelDescription = new string[4] { "Mantis", "Invasión", "Parasitos", "Jefe " }; //Lo que tu quieres ese es el orden de aparición
    public static string[] levelNames = new string[4] { "Mantis", "Invasión", "Parasitos", "Jefe " };
    public static bool firstTime = true;
    public static bool firstStats = true;
}
