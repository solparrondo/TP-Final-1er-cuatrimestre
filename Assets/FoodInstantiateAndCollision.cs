using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstantiateAndCollision : MonoBehaviour
{

    public GameObject objectToClone;

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
            SieteInstantiate();
        }
    }

    public void SieteInstantiate()
    {
        int counter = 0;
        while (counter < 7)
        {
            Instantiate(objectToClone);
            //objectToClone.transform.position()
            counter++;
        }
    }
}
