using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Button upLive;
    public Button downLive;
    public Text lifeNumber;
    public Button upAttack;
    public Button downAttack;
    public Text attackNumber;
    public Button upDefense;
    public Button downDefense;
    public Text defenseNumber;
    public Button upSpeed;
    public Button downSpeed;
    public Text speedNumber;
    public Text pointsNumber;

    public Button nextCharacter;
    public Button previousCharacter;
    int charac = 0;

    public Text nameCharacter;
    public SpriteRenderer spriteCharacter;

    int[,] characters;
    string[] names;
    [SerializeField] Sprite[] sprites;

    private string characterPrefsName = "Characters";

    private void Awake()
    {
        LoadData();
    }


    private void Update()
    {
        lifeNumber.text = characters[charac,0].ToString();
        attackNumber.text = characters[charac, 1].ToString();
        defenseNumber.text = characters[charac, 2].ToString();
        speedNumber.text = characters[charac, 3].ToString();
        pointsNumber.text = characters[charac, 4].ToString();
        nameCharacter.text = names[charac];

        spriteCharacter.sprite=sprites[charac];
    }

    private void OnDestroy()
    {
        SaveData();
    }
    public void UpLive()
    {
        if (characters[charac, 0] + 2 <= 40 && characters[charac, 4] > 0)
        {
            characters[charac, 0] += 2;
            characters[charac, 4]--;
        }
        
    }
    public void DownLive()
    {
        if (characters[charac, 0] - 2 >= 20 && characters[charac, 4] < 10)
        {
            characters[charac, 0] -= 2;
            characters[charac, 4]++;
        }
            
    }
    public void UpAttack()
    {
        if (characters[charac, 1] + 1 <= 10 && characters[charac, 4] > 0)
        {
            characters[charac, 1]++;
            characters[charac, 4]--;
        }
            
    }
    public void DownAttack()
    {
        if(characters[charac, 1] - 1 > 0 && characters[charac, 4] < 10)
        {
            characters[charac, 1]--;
            characters[charac, 4]++;
        }
        
    }
    public void UpDefense()
    {
        if (characters[charac, 2] + 1 <= 10 && characters[charac, 4] > 0)
        {
            characters[charac, 2]++;
            characters[charac, 4]--;
        }
            
    }
    public void DownDefense()
    {
        if (characters[charac, 2] - 1 > 0 && characters[charac, 4] < 10)
        {
            characters[charac, 2]--;
            characters[charac, 4]++;
        }
            
    }
    public void UpSpeed()
    {
        if (characters[charac, 3] + 1 <= 10 && characters[charac, 4] > 0)
        {
            characters[charac, 3]++;
            characters[charac, 4]--;
        }
            
    }
    public void DownSpeed()
    {
        if (characters[charac, 3] - 1 > 0 && characters[charac, 4] < 10)
        {
            characters[charac, 3]--;
            characters[charac, 4]++;
        }
            
    }

    public void UpCharacter()
    {
        if (charac == 5)
            charac = 0;
        else
            charac++;
    }
    public void DownCharacter()
    {
        if (charac == 0)
            charac = 5;
        else
            charac--;
    }

    private void SaveData()
    {
        /*
        PlayerPrefs.SetString(characterPrefsName, characters.ToString());
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Debug.Log(characters.ToString().Length);
            }
        }*/
        BetweenScenesControler.characters = characters;
    }
    private void LoadData()
    {
        /*
        string aux = PlayerPrefs.GetString(characterPrefsName, "1");
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                characters[i, j] = aux[i * 5 + j]; //juas juas esto no furula porque hay valores dobles
            }
        }*/
        characters = BetweenScenesControler.characters;
        names = BetweenScenesControler.names;
    }
}
