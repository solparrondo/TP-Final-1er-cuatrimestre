using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstantiateAndCollision : MonoBehaviour
{

    public GameObject objectToClone;
    float positionY = 0.7f;
   
    

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
        Instantiate(objectToClone);
        for (int z = -16; z < 11; z += 4)
        {
            for (int x = 92; x < 103; x += 2)
            {
                objectToClone.transform.position += new Vector3(x, positionY, z);
            }
        }

    }
}
