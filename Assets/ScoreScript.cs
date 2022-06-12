using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    int puntos = 0;
    int vidas = 3;
    public Text cantVidas;
    public GameObject muñecoToClone;
    public GameObject enemigoToClone;
    public GameObject muñeco;
    public GameObject enemigo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Comida")
        {
            puntos += 100;

        }
        else if (col.gameObject.tag == "Comida Especial")
        {
            puntos += 200;

        }
        else if (col.gameObject.tag == "Enemigo")
        {
            if (vidas == 3)
            {
                vidas -= 1;
                cantVidas.text = "Cantidad de vidas: ♡ ♡";

                Destroy(muñeco);
               Instantiate(muñecoToClone);
                muñecoToClone.transform.position += new Vector3(97.32f, 0.64f, -16.302f);

                Destroy(enemigo);
                Instantiate(enemigoToClone);
                enemigoToClone.transform.position += new Vector3(97.32f, 0.64f, -2.64f);
             
                //sonido de derrota
            }
            else if (vidas == 2)
            {
                vidas -= 1;
                cantVidas.text = "Cantidad de vidas: ♡ ";

                Destroy(muñeco);
                Instantiate(muñecoToClone);
                muñecoToClone.transform.position += new Vector3(97.32f, 0.64f, -16.302f);

                Destroy(enemigo);
                Instantiate(enemigoToClone);
                enemigoToClone.transform.position += new Vector3(97.32f, 0.64f, -2.64f);
                //sonido de derrota
            }
            else if (vidas == 1)
            {
                cantVidas.text = "0";
                //sonido de derrota
                //funcion para que aparezca una nueva escena donde diga finalizo el juego bla bla y muestre el puntaje 
                //y unboton para volver a comenzar el juego y que te lleve a la escena del juego donde empieza odo de nuevo
            }
            
        }
    }

    
}
