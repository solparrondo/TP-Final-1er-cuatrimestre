using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    // public AudioManager miAM;

    static int puntos;
    int vidas = 3;
    float tiempo = 0;
    int puntaje;

    bool stopTiempo = false;
    float fallZone = -0.5f;
    
   
    public GameObject muñeco;
    public GameObject enemigo;
    public Vector3 enemigoCloned;
    public Vector3 muñecoCloned;
   

    Text txtTiempo;
    AudioManager miAM;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        txtTiempo = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<UnityEngine.UI.Text>();
        txtTiempo.text = tiempo + " segundos";

        miAM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        
        
        if (stopTiempo == false)
        {
            tiempo = Mathf.Floor(Time.time);
        }

        if (gameObject.transform.position.y < fallZone) 
        {
            stopTiempo = true;
            miAM.playClipBoing();
          //  Destroy(muñeco);
            viewPanel("El juego ha finalizado, te haz caído.");
            
        }

        if (vidas == 3 && puntos == 5500 && tiempo <= 60)
        {
            puntaje = 6000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");

        }
        else if (vidas == 3 && puntos == 5500 && tiempo >= 60)
        {
            puntaje = 5500;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
        if (vidas == 2 && puntos == 5500 && tiempo <= 60)
        {

            puntaje = 5000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }

        else if (vidas == 2 && puntos == 5500 && tiempo >= 60)
        {
            puntaje = 4000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
        if (vidas == 1 && puntos == 5500 && tiempo >= 60 && tiempo <= 120)
        {
            puntaje = 3000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
        if (vidas == 1 && puntos == 5500 && tiempo >= 120)
        {
            puntaje = 1000;
            miAM.playClipVictoria();
            viewPanel("El juego ha finalizado, ¡has ganado!");
        }
       
    }



    public void viewPanel(string j)
    {
        
        // GameObject panel = GameObject.FindGameObjectWithTag("Panel").GetComponent<>();
        panel = GameObject.FindWithTag("Panel");
        Text txtVictoriaDerrota = GameObject.FindGameObjectWithTag("DerrotaVictoria").GetComponent<UnityEngine.UI.Text>();
        Text txtPuntaje = GameObject.FindGameObjectWithTag("Puntaje").GetComponent<UnityEngine.UI.Text>();

        stopTiempo = true; 
        
        /*RectTransform rt = panel.GetComponent<RectTransform>();
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 0);*/
        panel.transform.position = new Vector3(269,151,0);
       // panel.transform.right = new Vector3(0, 0);


        txtVictoriaDerrota.text = j;
        txtPuntaje.text = "Haz obtenido " + puntos + " puntos en " + tiempo + " segundos. \nTu puntaje final es " + puntaje;
   
    }

   public void changeScenee()
    {
       
       // panel.transform.position = new Vector3(0, 0, 0);
        SceneManager.LoadScene("ComenzarJuego");
        
    }

    

    void OnCollisionEnter(Collision col)
    {
        Text puntosComida = GameObject.FindGameObjectWithTag("PuntosComida").GetComponent<UnityEngine.UI.Text>();

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
            Text cantVidas = GameObject.FindGameObjectWithTag("CantVidas").GetComponent<UnityEngine.UI.Text>();

            if (vidas == 3 )
            {
               
                miAM.playClipDerrota();
                vidas -= 1;
                cantVidas.text = "Cantidad de vidas: ♡ ♡";
                //puntosComida.text = "Puntos por comida: " + puntos;

                muñeco.transform.position = muñecoCloned;
                enemigo.transform.position = enemigoCloned;
               
            }
            else if (vidas == 2)
            {
                miAM.playClipDerrota();
                vidas -= 1;
                cantVidas.text = "Cantidad de vidas: ♡ ";
                //puntosComida.text = "Puntos por comida: " + puntos;

                muñeco.transform.position = muñecoCloned;
                enemigo.transform.position = enemigoCloned; 
                
            }
            else if (vidas == 1)
            {
                miAM.playClipDerrotaFinal();
                vidas--;
                cantVidas.text = "Cantidad de vidas: 0 ";

                if (puntos > 0 && puntos < 5500 && tiempo <= 60)
                {
                    puntaje = 250;
                   // miAM.playClipDerrotaFinal();
                    viewPanel("El juego ha finalizado, no quedan más vidas");


                }
                if (puntos > 0 && puntos < 5500 && tiempo >= 120 )
                {
                    puntaje = 500;
                   // miAM.playClipDerrotaFinal();
                    viewPanel("El juego ha finalizado, no quedan más vidas");
                    
                }

             
            }
            
        }
    }

    
}
