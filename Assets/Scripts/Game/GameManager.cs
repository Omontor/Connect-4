using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Prefabs of checkers
    public GameObject player1, player2;
    //Text to tell the user who has the current turn
    public TMP_Text currentPlayerTag;
    //Array of possible locations to instantiate checkers
    public GameObject[] spawnLocations;
    //Array of clickable spaces
    public GameObject[] columns;
    //Parent for the checkers to be added
    public GameObject CheckerParent;



    private void Start()
    {
        //Assign id to each column
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i].GetComponent<ColumnManager>().number = i;
        }
    }

    //Here we instantiate the corresponding checker depending on the turn
    public void TakeTurn (int column)
    {
        var checker = Instantiate(player1, spawnLocations[column].transform.position, Quaternion.identity);
        checker.transform.SetParent(CheckerParent.transform);
    }

}
