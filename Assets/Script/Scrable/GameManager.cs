using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("LineRederer")]
    public LineManager lineManagerObj;
    [Header("InstantiatingObject")]
    public ItemScript ItemScriptObj;
    [Header("LevelManager")]
    public LevelManager levelManagerObj;
    
    public GameObject PointStorer, levelManagerStore, LevelComplete;
    public string WordToSplit;
    public int numerOfObjectToSpawn, Length_of_Word;
    GameObject ThreePointParentStore, FourPointParentStore, FivePointParentStore, SixPointParentStore, SevenPointParentStore, EightPointParentStore, NinePointParentStore, TenPointParentStore,RollStorer;
    public List<GameObject> List_Of_Level=new List<GameObject>();
    public GameObject LevelToStart, LevelNameStore,LevelOne, LevelTwo, LevelThree, LevelFour, LevelFive, LevelSix,LevelSeven,LevelEight;
    public List<string> ListOfWords=new List<string>();
    int j = 0,k=1;
    public AudioSource audioPlayer;
    public AudioClip m_audioClip;
    GameObject PlayButtonStore,Menu_m,Panel_m;

    void Awake()
    {
        Menu_m = GameObject.Find("Menu");
        Panel_m = GameObject.Find("Panel");
        Panel_m.SetActive(false);
        PlayButtonStore=GameObject.Find("PlayButton");
        PlayButtonStore.GetComponent<Button>().onClick.AddListener(onClickPlay);
        /*LevelComplete.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(onClickContinue);
        audioPlayer.PlayOneShot(m_audioClip);
        ThreePointParentStore = GameObject.Find("ThreePoint");
        FourPointParentStore = GameObject.Find("FourPoint");
        FivePointParentStore = GameObject.Find("FivePoint");
        SixPointParentStore = GameObject.Find("SixPoint");
        SevenPointParentStore = GameObject.Find("SevenPoint");
        EightPointParentStore = GameObject.Find("EightPoint");
        NinePointParentStore = GameObject.Find("NinePoint");
        TenPointParentStore = GameObject.Find("TenPoint");
        RollStorer = GameObject.Find("Roll");
        LevelNameStore = GameObject.Find("LevelName");

        RollStorer.SetActive(false);
        ThreePointParentStore.SetActive(false);
        FourPointParentStore.SetActive(false);
        FivePointParentStore.SetActive(false);
        SixPointParentStore.SetActive(false);
        SevenPointParentStore.SetActive(false);
        EightPointParentStore.SetActive(false);
        NinePointParentStore.SetActive(false);
        TenPointParentStore.SetActive(false);
        LevelNameStore.SetActive(false) ;
        levelManagerStore.SetActive(false);
        StartNewLevel();*/
    }

    void onClickPlay()
    {
        Menu_m.SetActive(false);
        Panel_m.SetActive(true);
        LevelComplete.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(onClickContinue);
        audioPlayer.PlayOneShot(m_audioClip);
        ThreePointParentStore = GameObject.Find("ThreePoint");
        FourPointParentStore = GameObject.Find("FourPoint");
        FivePointParentStore = GameObject.Find("FivePoint");
        SixPointParentStore = GameObject.Find("SixPoint");
        SevenPointParentStore = GameObject.Find("SevenPoint");
        EightPointParentStore = GameObject.Find("EightPoint");
        NinePointParentStore = GameObject.Find("NinePoint");
        TenPointParentStore = GameObject.Find("TenPoint");
        RollStorer = GameObject.Find("Roll");
        LevelNameStore = GameObject.Find("LevelName");

        RollStorer.SetActive(false);
        ThreePointParentStore.SetActive(false);
        FourPointParentStore.SetActive(false);
        FivePointParentStore.SetActive(false);
        SixPointParentStore.SetActive(false);
        SevenPointParentStore.SetActive(false);
        EightPointParentStore.SetActive(false);
        NinePointParentStore.SetActive(false);
        TenPointParentStore.SetActive(false);
        LevelNameStore.SetActive(false);
        levelManagerStore.SetActive(false);
        StartNewLevel();
    }

    public void StartNewLevel()
    {
        print(" value of j is " + j);
        WordToSplit = ListOfWords[j];
        TMP_Text levelName = LevelNameStore.GetComponent<TMP_Text>();
        levelName.text = "Level " +k;
        print(WordToSplit);
        Length_of_Word = WordToSplit.Length;
        print("the length of word is " + Length_of_Word);
        numerOfObjectToSpawn = Length_of_Word;
        RollStorer.SetActive(true);
        if (Length_of_Word == 3)
        {
            PointStorer = ThreePointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = LevelOne;
        }
        else if (Length_of_Word == 4)
        {
            PointStorer = FourPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = LevelTwo;
        }
        else if (Length_of_Word == 5)
        {
            PointStorer = FivePointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            
            LevelToStart = LevelThree;
        }
        else if (Length_of_Word == 6)
        {
            PointStorer = SixPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = LevelFour;
        }
        else if(Length_of_Word == 7)
        {
            PointStorer = SevenPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = LevelFive;
        }
        else if (Length_of_Word == 8)
        {
            PointStorer = EightPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = LevelSix;
        }
        else if (Length_of_Word == 9)
        {
            PointStorer = NinePointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = LevelSeven;
        }
        else if (Length_of_Word == 8)
        {
            PointStorer = TenPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = LevelEight;
        }
    }

    public void GameOver()
    {
        print("word before change" + WordToSplit);
        WordToSplit = "";
        levelManagerObj.concatenatedString = "";
        print("word after change" + WordToSplit);
       
        RollStorer.SetActive(false);
        PointStorer.SetActive(false);
        LevelToStart.SetActive(false);
        LevelNameStore.SetActive(false);
        LevelComplete.SetActive(true);

    }

    public void onClickContinue()
    {
        LevelComplete.SetActive(false); 
        PointStorer.SetActive(false);
        levelManagerStore.SetActive(false);
        k = k + 1;
        j = j + 1;                                   //increasing the value of listOfwords
        print("Updated Value of j is " + j);
        StartNewLevel();
    }
}

