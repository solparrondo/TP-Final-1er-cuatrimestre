﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagerScript : MonoBehaviour
{
    public Button btn; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("BtnComenzarJuego")) {

            SceneManager.LoadScene("Juego");
       }
       
       
    }

   
}
