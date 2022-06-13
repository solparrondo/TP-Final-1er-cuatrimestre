using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public AudioManager miAM;
    int puntos = 0;
    int vidas = 3;
    float tiempo = 0;
    bool stopTiempo = true;
    float fallZone = -0.5f;
    public Text cantVidas;
    public Text puntosComida;
    public GameObject muñecoToClone;
    public GameObject enemigoToClone;
    public GameObject muñeco;
    public GameObject enemigo;
    public Vector3 enemigoCloned;
    public Vector3 muñecoCloned;
    int puntaje;
    public Text txtPuntaje;
    public Text txtVictoriaDerrota;
    // public Button btnVolverAJugar;
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTiempo == true)
        {
            tiempo = Mathf.Floor(Time.time);
        }

        if (muñeco.transform.position.y < fallZone) 
        {
            stopTiempo = false;
            miAM.playClipBoing();
            Destroy(muñeco);
            viewPanel("El juego ha finalizado, te haz caído.");
            
        }

        if (vidas == 3 && puntos == 4200 && tiempo <= 60)
        {
            puntaje = 6000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");

        }
        else if (vidas == 3 && puntos == 4200 && tiempo >= 60)
        {
            puntaje = 4200;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
        if (vidas == 2 && puntos == 4200 && tiempo <= 60)
        {

            puntaje = 4000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }

        else if (vidas == 2 && puntos == 4200 && tiempo >= 60)
        {
            puntaje = 3000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
        if (vidas == 1 && puntos == 4200 && tiempo >= 60 && tiempo <= 120)
        {
            puntaje = 2000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
        if (vidas == 1 && puntos == 4200 && tiempo >= 120)
        {
            puntaje = 1000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
       
    }



    public void viewPanel(string j)
    {
        stopTiempo = false;
        panel.SetActive(true);
        txtVictoriaDerrota.text = j;
        txtPuntaje.text = "Haz obtenido " + puntos + " puntos en " + tiempo + " segundos. \nTu puntaje final es " + puntaje;
   
    }

    public void changeScene()
    {
        SceneManager.LoadScene("ComenzarJuego");
    }

    

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Comida")
        {
            puntos += 50;
            puntosComida.text = "Puntos por comida: " + puntos;

        }
        else if (col.gameObject.tag == "Comida Especial")
        {
            puntos += 100;
            puntosComida.text = "Puntos por comida: " + puntos;

        }
        else if (col.gameObject.tag == "Enemigo")
        {
            if (vidas == 3)
            {
                miAM.playClipDerrota();
                vidas -= 1;
                cantVidas.text = "Cantidad de vidas: ♡ ♡";


                Instantiate(muñecoToClone);
                muñecoToClone.transform.position = muñecoCloned;
                Destroy(muñeco);


                Instantiate(enemigoToClone);
                enemigoToClone.transform.position = enemigoCloned;
                Destroy(enemigo);

            }
            else if (vidas == 2)
            {
                miAM.playClipDerrota();
                vidas -= 1;
                cantVidas.text = "Cantidad de vidas: ♡ ";

                Destroy(muñeco);
                Instantiate(muñecoToClone);
                muñecoToClone.transform.position = muñecoCloned;

                Destroy(enemigo);
                Instantiate(enemigoToClone);
                enemigoToClone.transform.position = enemigoCloned;
                
            }
            else if (vidas == 1)
            {
                miAM.playClipDerrota();
                vidas--;
                cantVidas.text = "0";

                if (puntos > 0 && puntos < 4200 && tiempo <= 60)
                {
                    puntaje = 250;
                    miAM.playClipDerrota();
                    viewPanel("El juego ha finalizado, no quedan más vidas");


                }
                if (puntos > 0 && puntos < 4200 && tiempo >= 120 )
                {
                    puntaje = 500;
                    miAM.playClipDerrota();
                    viewPanel("El juego ha finalizado, no quedan más vidas");
                    
                }

             
            }
            
        }
    }

    
}
