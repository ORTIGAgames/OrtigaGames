using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenesControler : MonoBehaviour
{
    public static int[,] characters = new int[6, 4] { { 28, 4, 5,  5 }, { 24, 5, 6,  5 }, { 22, 2, 3,  5 }, { 30, 4, 7,  5 }, { 26, 5, 4,  5 }, { 20, 7, 3,  5 } };
    public static string[] names = new string[6] { "Declan", "Winnie", "G470", "Nass", "Norbert", "Caroline" };
    public static string[] namesEnemies = new string[6] { "Himenopio F", "Himenopio M", "Krandle", "Parasito", "HARNCKXSHOR", "Minion" };
    public static string[,] backgrounds = new string[4,6] { { "Declan", "Winnie", "G470", "Nass", "Norbert", "Caroline" }, { "a", "b", "c", "d", "e", "f" }, { "1", "2", "3", "4", "5", "6" },{ "enemi1", "e2", "e3", "e4", "e5", "e6" } };
    public static string[] levelDescription = new string[4] { "Mantis", "Invasión", "Parasitos", "Jefe " };
    public static string[] levelNames = new string[4] { "Mantis", "Invasión", "Parasitos", "Jefe " };
    public static bool firstTime = true;
    public static bool firstStats = true;
}
