using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

     float movementSpeed = 0.6f;
   
 // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-movementSpeed, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(movementSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0, 0, -movementSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0, 0, movementSpeed);
        }

       
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Pared")
        {
        

        }
    }



}
