using System.Collections;
using System.Collections.Generic;
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
    GameObject ThreePointParentStore, FourPointParentStore, FivePointParentStore, SixPointParentStore, SevenPointParentStore, EightPointParentStore,RollStorer;
    public List<GameObject> List_Of_Level=new List<GameObject>();
    /*public GameObject LevelToStart,LevelOne,LevelTwo,LevelThree,LevelFour,LevelFive;*/
    public GameObject LevelToStart,threeLetterWordLevel,FourLetterWordLevel,FiveLetterWordLevel,SixLetterWordLevel,SevenLetterWordLevel, EightLetterWordLevel;
    public List<string> ListOfWords=new List<string>();
    int j = 0;
    public AudioSource audioPlayer;
    public AudioClip m_audioClip;

    void Awake()
    {
        LevelComplete.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(onClickContinue);
        audioPlayer.PlayOneShot(m_audioClip);
        ThreePointParentStore = GameObject.Find("ThreePoint");
        FourPointParentStore = GameObject.Find("FourPoint");
        FivePointParentStore = GameObject.Find("FivePoint");
        SixPointParentStore = GameObject.Find("SixPoint");
        SevenPointParentStore = GameObject.Find("SevenPoint");
        RollStorer = GameObject.Find("Roll");
        

        RollStorer.SetActive(false);
        ThreePointParentStore.SetActive(false);
        FourPointParentStore.SetActive(false);
        FivePointParentStore.SetActive(false);
        SixPointParentStore.SetActive(false);
        SevenPointParentStore.SetActive(false);
        levelManagerStore.SetActive(false);
        StartNewLevel();
    }

    public void StartNewLevel()
    {
        print(" value of j is " + j);
        /*WordToSplit = GameObject.Find("Header").transform.GetChild(0).GetComponent<TMP_Text>().text;*/
        WordToSplit = ListOfWords[j];
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
            /*LevelToStart=LevelOne;*/
            LevelToStart = threeLetterWordLevel;
            /*ThreePointParentStore.SetActive(true);*/
        }
        else if (Length_of_Word == 4)
        {
            PointStorer = FourPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            /*LevelToStart=LevelTwo;*/
            LevelToStart = FourLetterWordLevel;
            /*FourPointParentStore.SetActive(true);*/
        }
        else if (Length_of_Word == 5)
        {
            PointStorer = FivePointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            LevelToStart = FiveLetterWordLevel;
            /*LevelToStart = LevelThree;*/
            /*FivePointParentStore.SetActive(true);*/
        }
        else if (Length_of_Word == 6)
        {
            PointStorer = SixPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            /*LevelToStart = LevelFour;*/
            LevelToStart=SixLetterWordLevel;
            /*SixPointParentStore.SetActive(true);*/
        }
        else if(Length_of_Word == 7)
        {
            PointStorer = SevenPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            /*LevelToStart = LevelFive;*/
            LevelToStart = SevenLetterWordLevel;
            /* SevenPointParentStore.SetActive(true);*/
        }
        else if (Length_of_Word == 8)
        {
            PointStorer = EightPointParentStore;
            PointStorer.SetActive(true);
            levelManagerStore.SetActive(true);
            /*LevelToStart = LevelFive;*/
            LevelToStart = EightLetterWordLevel;
            /* SevenPointParentStore.SetActive(true);*/
        }
    }

    public void GameOver()
    {
        print("word before change" + WordToSplit);
        WordToSplit = "";
        levelManagerObj.concatenatedString = "";
        print("word after change" + WordToSplit);
        /*GameObject.Find("Header").transform.GetChild(0).GetComponent<TMP_Text>().text = "";*/
        RollStorer.SetActive(false);
        PointStorer.SetActive(false);
        
        
       
        levelManagerObj.ActiveLevel.gameObject.SetActive(false);
        LevelComplete.SetActive(true);
    }

    public void onClickContinue()
    {
        LevelComplete.SetActive(false);
        
        
        /*ItemScriptObj.lineManagerGameObject.SetActive(false);*/
        PointStorer.SetActive(false);
        levelManagerStore.SetActive(false);

        /*GameObject.Find("Header").transform.GetChild(0).GetComponent<TMP_Text>().text = "app";*/
        levelManagerObj.currentLevelNumber = levelManagerObj.currentLevelNumber + 1;
        if (levelManagerObj.currentLevelNumber == 10)
        {
            LevelToStart.SetActive(false);
            levelManagerObj.currentLevelNumber = 0;
            levelManagerObj.isChapterOn = false;
        }
        j =j+1;       //increasing the value of listOfwords
        print("update value of j is " + j);
        StartNewLevel();
        /*if (WordToSplit == "")
        {
            StartNewLevel();
        }
        else
        {
            print("No words Remaining, Game Completed");
        }*/
        
        /*if (WordToSplit != null)
        {
            print("Header is not Empty");
            StartNewLevel();
        }
        else
        {
            print("Header is Empty");
        }*/
    }


}

