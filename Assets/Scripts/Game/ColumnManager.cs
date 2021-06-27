using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnManager : MonoBehaviour
{
    //Game Manager Referebce
    public GameManager gm;
    //Column's ID
    public int number;

    private void Start()
    {
        //Add button listener at the begining of the game
        gameObject.GetComponent<Button>().onClick.AddListener(clickedAction);
    }

    //Once user clicks, we call the action on GameManager
     void clickedAction()
    {
        Debug.Log("You just pressed column " + number);
        //Use current id to indicate which column was pressed
        gm.TakeTurn(number);
        //Disable buttons momentarily
        gm.StartCoroutine("CoolOffButton");
    }
    
}
