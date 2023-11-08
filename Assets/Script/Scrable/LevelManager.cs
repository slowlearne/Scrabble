using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ItemScript ItemScriptObj;
    public LineManager lineManagerObj;
    public GameManager GameManagerObj;
    public GameObject ImageObject,ImageObject1, GameLevels, instantiatedItem,instantiatedItemOnLevel;
    public char[] ArrayOfCharacter, ArrayOfWordSplit;
    public List<GameObject> instantiatedObjects = new List<GameObject>();
    public List<GameObject> instantiatedItemOnLevelList= new List<GameObject>();
    public List<Transform> ChildPointsList = new List<Transform>();
    public List<string> List_for_letter;
    List<char> List_Of_Character=new List<char>();
    public string concatenatedString;
    public TMP_Text image_Letter, LevelLetterStorer;
   void OnEnable()
    {
        StartCoroutine(StartSequence());
    }
    private void OnDisable()
    {
        StopCoroutine(StartSequence());
    }
    IEnumerator StartSequence()
    {
        yield return null;
        GameManagerObj.LevelToStart.SetActive(true);
        GameManagerObj.LevelNameStore.SetActive(true);
        List_for_letter = new List<string>();
        for (int i = 0; i < GameManagerObj.numerOfObjectToSpawn; i++)
        {
            //Instantiating image and adding to list
            instantiatedItem = Instantiate(ImageObject, GameManagerObj.PointStorer.transform.GetChild(i).transform.position, Quaternion.identity, GameManagerObj.PointStorer.transform.GetChild(i));
            instantiatedObjects.Add(instantiatedItem);
            // instantiated image1 and adding to list 
            instantiatedItemOnLevel = Instantiate(ImageObject1, GameManagerObj.LevelToStart.transform.GetChild(i).transform.position, Quaternion.identity, GameManagerObj.LevelToStart.transform.GetChild(i));
            instantiatedItemOnLevelList.Add(instantiatedItemOnLevel);

        }
        GameManagerObj.WordToSplit = GameManagerObj.WordToSplit.ToUpper();
        
        ArrayOfWordSplit = GameManagerObj.WordToSplit.ToCharArray();
        
        ArrayOfCharacter = GameManagerObj.WordToSplit.ToCharArray();

        System.Random rng = new System.Random();
        int n = ArrayOfCharacter.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            char value = ArrayOfCharacter[k];
            ArrayOfCharacter[k] = ArrayOfCharacter[n];
            ArrayOfCharacter[n] = value;
        }

        for (int i = 0; i < ArrayOfCharacter.Length; i++)
        {
            ChildPointsList.Add(GameManagerObj.PointStorer.transform.GetChild(i));
            print("child list contain" + ChildPointsList[i]);
        }

        for (int i = 0; i < ArrayOfCharacter.Length; i++)               //Taking letter from ArrayOfWordSplit[] and displaying in image 
        {
            image_Letter = ChildPointsList[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
            image_Letter.text = ArrayOfCharacter[i].ToString();
            print("Letter in ImageText is " + image_Letter.text);
        }

    }
public IEnumerator Add_letter_ToList(string letterReceived)                //Adding Letter to List_for_letter after OnPointerEnter is called. 
    {
        List_for_letter.Add(letterReceived);
        Debug.Log("the letter added in List_for_letter is " + letterReceived);
        print("Count of List_for_letter is " + List_for_letter.Count);

        LevelLetterStorer = GameManagerObj.LevelToStart.transform.GetChild(List_for_letter.Count - 1).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
        LevelLetterStorer.text = letterReceived;

        //After All Letters are included in List_for_letter

        if (List_for_letter.Count == ArrayOfWordSplit.Length)             //Checking if they are Equal
        {
            print("the List_for_letter Count and ArrayOfWordSplit Length is Equal");
           for(int i = 0; i < List_for_letter.Count; i++)
            {
                print("List_for_letter has " + List_for_letter[i]);
                print(" ArrayOfWordSplit has " + ArrayOfWordSplit[i]);
                
                if ((ArrayOfWordSplit[i].ToString()).Equals(List_for_letter[i]))       //checking if they both contain same letter
                {
                    print("Both Letter are in Same Order");
                    concatenatedString = concatenatedString + List_for_letter[i];
                    print("After Concatenation the Letters are " + concatenatedString);
                }
            }
            if (concatenatedString.Equals(GameManagerObj.WordToSplit))
            {
                print("The Given Word and Connected Letter are same, GameOver! ");
                yield return new WaitForSeconds(1f);
                for (int i = 0; i < List_for_letter.Count; i++)
                {
                    LevelLetterStorer = GameManagerObj.LevelToStart.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
                    LevelLetterStorer.text = "";
                }
                List_for_letter.Clear();
                ChildPointsList.Clear();
                lineManagerObj.lineCreator.positionCount = 0;
                lineManagerObj.lineCreator.enabled = false;
                lineManagerObj.linesList.Clear();
                print("line list is cleared");
                ItemScriptObj.lineManagerGameObject.SetActive(false);
                UndoInstantiatedObjects();
                GameManagerObj.GameOver();
            }
        }
        yield return new WaitForSeconds(0.2f);
    }
    public void UndoInstantiatedObjects()
    {
        for(int i=0;i<instantiatedObjects.Count;i++)
        {
            Destroy(instantiatedObjects[i]);
            
        }
        for (int i = 0; i < instantiatedItemOnLevelList.Count; i++)
        {
            Destroy(instantiatedItemOnLevelList[i]);
        }

        // Clear the list to remove references to the destroyed objects
        instantiatedObjects.Clear();
    }



}
