using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstantiateAndCollision : MonoBehaviour
{

    public GameObject objectToClone;
    int positionY = 1;
   
    

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
        if (col.gameObject.tag == "Muñeco")
        {
            Destroy(gameObject);
            DosInstantiate();
           
        }
    }

    public void DosInstantiate()
    {
        int counter = 1;
        while (counter <= 2)
        {
            Instantiate(objectToClone);
            counter++;
            objectToClone.transform.position = new Vector3(Random.Range(93, 102), positionY, Random.Range(-14, 10));
        }
       
        //Random z = new Random
   
        
       
    }
}
