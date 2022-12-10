using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    //Stats
    public Button upLive;
    public Button downLive;
    public Text lifeNumber;
    public Button upAttack;
    public Button downAttack;
    public Text attackNumber;
    public Button upDefense;
    public Button downDefense;
    public Text defenseNumber;
    public Text pointsNumber;
    public Text nameCharacter;
    public SpriteRenderer spriteCharacter;

    //Glossary
    public Text info;
    public GameObject panel;
    int type = 0;
    bool enemy = false;
    bool image = false;
    public Text nameCharacterGlossary;
    public SpriteRenderer spriteCharacterGlossary;

    //Levels
    public Text nameLevel;
    public Text descriptionLevel;
    public SpriteRenderer spriteLevel;
    public SpriteRenderer spriteEnemies1;
    public SpriteRenderer spriteEnemies2;


    public Button nextCharacter;
    public Button previousCharacter;
    int charac = 0;
    int level = 0;
    int enemies = 0;

    int[,] characterStats;
    int[,] characterInitialStats = new int[6, 3] { { 24, 4, 5 }, { 24, 5, 4 }, { 26, 2, 4 }, { 30, 3, 7 }, { 20, 5, 4 }, { 20, 7, 2 } };
int upgradePoints;
    string[] names;
    string[] namesEnemies;
    string[,] charactersTexts;
    string[,] enemiesTexts;
    string[] levelNames;
    string[] descriptionLevels;
    
    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite[] spritesEnemies;
    [SerializeField] Sprite[] spritesGlossary;
    [SerializeField] Sprite[] levelsImage;
    [SerializeField] Sprite[] levelEnemies1;
    [SerializeField] Sprite[] levelEnemies2;
    [SerializeField] Button[] levels;


    //private string characterPrefsName = "Characters";

    private void Awake()
    {
        LoadData();
    }


    private void Update()
    {
        if (BetweenScenesControler.level1 == true)
        {
            levels[1].interactable = true;
        }
        else
        {
            levels[1].interactable = false;
        }
        if (BetweenScenesControler.level2 == true)
        {
            levels[2].interactable = true;
        }
        else
        {
            levels[2].interactable = false;
        }
        if (BetweenScenesControler.level3 == true)
        {
            levels[3].interactable = true;
        }
        else
        {
            levels[3].interactable = false;
        }

        lifeNumber.text = characterStats[charac,0].ToString();
        attackNumber.text = characterStats[charac, 1].ToString();
        defenseNumber.text = characterStats[charac, 2].ToString();
        pointsNumber.text = upgradePoints.ToString();
        nameCharacter.text = names[charac];
        spriteCharacter.sprite = sprites[charac];

        nameLevel.text = levelNames[level];
        descriptionLevel.text = descriptionLevels[level];
        spriteLevel.sprite = levelsImage[level];
        spriteEnemies1.sprite = levelEnemies1[level];
        spriteEnemies2.sprite = levelEnemies2[level];

        foreach (Button b in levels)
        {
            b.gameObject.SetActive(false);
        }
        levels[level].gameObject.SetActive(true);

        if (image == true)
        {
            spriteCharacterGlossary.gameObject.SetActive(true);
            panel.active = false;
        }
        else
        {
            spriteCharacterGlossary.gameObject.SetActive(false);
            panel.active = true;
        }
        if (enemy==true)
        {
            nameCharacterGlossary.text = namesEnemies[enemies];
            spriteCharacterGlossary.sprite = spritesEnemies[enemies];
            info.text = enemiesTexts[type, enemies];
        }
        else
        {
            nameCharacterGlossary.text = names[charac];
            spriteCharacterGlossary.sprite = spritesGlossary[charac];
            info.text = charactersTexts[type, charac];
        }
        BetweenScenesControler.upgradePoint = upgradePoints;

    }
    public void typeText(int t)
    {
        type = t;
    }
    public void Enemies()
    {
        enemy = true;
    }
    public void Allies()
    {
        enemy = false;
    }
    public void Image()
    {
        image = true;
    }
    public void NoImage()
    {
        image = false;
    }
    private void OnDestroy()
    {
        SaveData();
    }
    public void UpLive()
    {
        if (characterStats[charac, 0] + 2 <= 40 && upgradePoints > 0)
        {
            characterStats[charac, 0] += 2;
            upgradePoints--;
        }
        
    }
    public void DownLive()
    {
        if (characterStats[charac, 0] - 2 >= characterInitialStats[charac, 0] && upgradePoints < 10)
        {
            
            characterStats[charac, 0] -= 2;
            upgradePoints++;
        }
            
    }
    public void UpAttack()
    {
        if (characterStats[charac, 1] + 1 <= 10 && upgradePoints > 0)
        {
            characterStats[charac, 1]++;
            upgradePoints--;
        }
            
    }
    public void DownAttack()
    {
        if(characterStats[charac, 1] - 1 >= characterInitialStats[charac, 1] && upgradePoints < 10)
        {
            characterStats[charac, 1]--;
            upgradePoints++;
        }
        
    }
    public void UpDefense()
    {
        if (characterStats[charac, 2] + 1 <= 10 && upgradePoints > 0)
        {
            characterStats[charac, 2]++;
            upgradePoints--;
        }
            
    }
    public void DownDefense()
    {
        if (characterStats[charac, 2] - 1 >= characterInitialStats[charac, 2] && upgradePoints < 10)
        {
            characterStats[charac, 2]--;
            upgradePoints++;
        }
            
    }
    

    public void UpCharacter()
    {
        if (charac == 5)
            charac = 0;
        else
            charac++;
        enemies = charac;

        if (level == 3)
            level = 0;
        else
            level++;
    }
    public void DownCharacter()
    {
        if (charac == 0)
            charac = 5;
        else
            charac--;
        enemies = charac;

        if (level == 0)
            level = 3;
        else
            level--;
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
        BetweenScenesControler.characters = characterStats;
        
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
        characterStats = BetweenScenesControler.characters;
        upgradePoints = BetweenScenesControler.upgradePoint;
        names = BetweenScenesControler.names;
        namesEnemies = BetweenScenesControler.namesEnemies;
        charactersTexts = BetweenScenesControler.backgrounds;
        enemiesTexts = BetweenScenesControler.backgroundsEnemies;
        levelNames= BetweenScenesControler.levelNames;
        descriptionLevels = BetweenScenesControler.levelDescription;
    }
}
