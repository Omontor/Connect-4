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

    //Number of spaces in the board
    int boardHeight = 6;
    int boardWidth = 7;
    // @D Array so we know which spaces are taken 
    int[,] boardState; 
    // 0 is empty, 1 is player1, 2 is CPU


    private void Start()
    {
        //Assign id to each column
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i].GetComponent<ColumnManager>().number = i;
        }


        boardState = new int[boardWidth, boardHeight];

        player1Turn = true;
        //Start with player's turn
        SwitchTurns();
    }

    public void selectColumn(int column)
    {
        //Check if there's any slot available
        if (updateBoardState(column))
        {
            //If so, we start the turn
            TakeTurn(column);
            //Disable buttons momentarily
            StartCoroutine("CoolOffButton");
        } 
        
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
            player1Turn = false;
        }
        //If it's the CPU's turn we run instantiate the other checker
        else
        {
               //Instantiate and move to parent
            var checker = Instantiate(player2, spawnLocations[column].transform.position, Quaternion.identity);
            checker.transform.SetParent(CheckerParent.transform);
            player1Turn = true;
        }

  
    }



    public void SwitchTurns()
    {
       
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
            //enable component's interactability
            columns[i].GetComponent<Button>().interactable = true;
            Debug.Log("Every column is re-enabled");
        }
        //Switch turn after checker drops
        SwitchTurns();
    }

     bool updateBoardState (int column)
    {   //We go through the array to see which spot is available
        for (int row = 0; row < boardHeight; row++)
        {   //if a spot is empty (0) we'll spawn there
            if (boardState[column, row] == 0)
            {   //if it's player turn we assign 1 value to the empty spot
                if (player1Turn)
                {
                    boardState[column, row] = 1;
                }
                else
                { //if it's CPU turn we assign 1 value to the empty spot
                    boardState[column, row] = 2;
                }
                //If the checker is placeable we add it to our array
                Debug.Log("Checker placed at " + column + ", " + row);
                return true;
            }
        }
        //If not we don't move forward
        Debug.Log("column " + column + " is full");
        return false;
    }

   
}
