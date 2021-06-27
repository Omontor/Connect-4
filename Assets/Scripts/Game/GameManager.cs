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


    //Here we instantiate the corresponding checker depending on the turn
    public void TakeTurn (int column)
    {
        Instantiate(player1, spawnLocations[column].transform.position, Quaternion.identity);
    }

}
