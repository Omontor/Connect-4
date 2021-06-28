using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkers : MonoBehaviour
{

    
    public Vector3 initial;

    // Start is called before the first frame update
    void Start()
    {
        //Storing first position to recycle it
        initial = gameObject.transform.position;
        //Add a random value to gravity to change the speed
        gameObject.GetComponent<Rigidbody2D>().gravityScale = Random.RandomRange(1, 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Once the checker has moved through all the screen we relocate it at its original position with a new gravity force
        gameObject.transform.position = new Vector3(initial.x, initial.y, initial.z);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = Random.RandomRange(1, 6);
    }
}
