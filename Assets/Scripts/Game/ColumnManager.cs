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
        gameObject.GetComponent<Button>().onClick.AddListener(clickedAction);
    }

     void clickedAction()
    {
        Debug.Log("You just pressed column " + number);
        gm.TakeTurn(number);
    }
    
}
