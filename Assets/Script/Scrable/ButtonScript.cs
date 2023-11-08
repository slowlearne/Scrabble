using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Experimental.AI;

public class ButtonScript : MonoBehaviour
{
    public GameManager gameManagerObj;
    public LevelManager levelManagerObj;
    int newValue;
    public GameObject GameObjectForCenterPoint;


    public List<Transform> OnButtonClick_new_List = new List<Transform>();
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        GetComponent<Button>().interactable = false;

        for (int i=0;i<levelManagerObj.ChildPointsList.Count;i++) 
        {
            OnButtonClick_new_List.Add(levelManagerObj.ChildPointsList[i]);
        }
        moveItemsToCenter();
    }
    Coroutine moveItemToNewPlace;
    public void moveItemsToCenter()
    {
        print("count of instantiate object" + levelManagerObj.instantiatedObjects.Count);
        for (int i = 0; i < levelManagerObj.instantiatedObjects.Count; i++)
        {
            print("move item to center "+ i);
            LeanTween.move(levelManagerObj.instantiatedObjects[i], GameObjectForCenterPoint.transform.position, 0.5f).setOnComplete(() =>
            {
                print(levelManagerObj.instantiatedObjects.Count - 1);
                print("i value" + i);
                if (i == levelManagerObj.instantiatedObjects.Count)
                {
                   if(moveItemToNewPlace == null)
                   moveItemToNewPlace = StartCoroutine(MoveItemToNewPlace());

                }
            });
        }

    }

    public IEnumerator MoveItemToNewPlace()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < levelManagerObj.instantiatedObjects.Count; i++)
        {
            newValue = Random.Range(0, OnButtonClick_new_List.Count);
            LeanTween.move(levelManagerObj.instantiatedObjects[i], OnButtonClick_new_List[newValue].transform.position, 0.1f);
            OnButtonClick_new_List.Remove(OnButtonClick_new_List[newValue]);
        }
        yield return new WaitForSeconds(0.2f);
        moveItemToNewPlace = null;
        GetComponent<Button>().interactable = true;
    }
}
