using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Checker Prefabs
    public GameObject player1, player2;
    // User Sprites
    public GameObject playerSprite, CPUSprite;
    //Text to tell the user who has the current turn
    public TMP_Text currentPlayerTag;
    //Array of possible locations to instantiate checkers
    public GameObject[] spawnLocations;
    //Array of clickable spaces
    public GameObject[] columns;
    //Parent for the checkers to be added
    public GameObject CheckerParent;
    // Bool to determine which player goes next
    bool player1Turn;
    // Time interval between turns to avoid doble clicking and glitches
    public int timeInterval;

    private void Start()
    {
        //Assign id to each column
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i].GetComponent<ColumnManager>().number = i;
        }
        //Start with player's turn
        SwitchTurns();
    }

     
    //Here we instantiate the corresponding checker depending on the turn
    public void TakeTurn (int column)
    {
        //Check to see if it's player 1's turn (depending on the bool)
        if (player1Turn)
        {
            //If it is we instantiate the corresponding checker on the column
            var checker = Instantiate(player1, spawnLocations[column].transform.position, Quaternion.identity);
            //Once instantiated we move it as a child of Checkerpartent to keep al the checkers in one place
            checker.transform.SetParent(CheckerParent.transform);
        }
        //If it's the CPU's turn we run instantiate the other checker
        else
        {
               //Instantiate and move to parent
            var checker = Instantiate(player2, spawnLocations[column].transform.position, Quaternion.identity);
            checker.transform.SetParent(CheckerParent.transform);
        }

        //Switch turn after instantiating
        SwitchTurns();
    }



    public void SwitchTurns()
    {
        //Toggle bool state
        player1Turn = !player1Turn;
        //Change current user text
        if (player1Turn)
        {
            //Change text to User
            currentPlayerTag.text = "User";
            playerSprite.SetActive(true);
            CPUSprite.SetActive(false);
        }
        else
        {
            //Change text to CPU
            currentPlayerTag.text = "CPU";
            playerSprite.SetActive(false);
            CPUSprite.SetActive(true);
        }
    }


    public IEnumerator CoolOffButton()
    {
        // Disable every column by cicling trhough the array
        for (int i = 0; i < columns.Length; i++)
        {
            //disable component's interactability
            columns[i].GetComponent<Button>().interactable = false;
            Debug.Log("Every column disabled");
        }
        //Wait
        yield return new WaitForSeconds(timeInterval);
        //Re- enable
        for (int i = 0; i < columns.Length; i++)
        {
            //disable component's interactability
            columns[i].GetComponent<Button>().interactable = true;
            Debug.Log("Every column is re-enabled");
        }

    }
}
