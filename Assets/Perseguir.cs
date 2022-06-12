using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    float speedPosition = 1;
   // int speedRotation = 0;
   public Transform target;

   public Transform targetTR;
   public Transform targetTRR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speedPosition * Time.deltaTime);
         // transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speedRotation * Time.deltaTime);
         var step = speedPosition * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, targetTR.position, step);

         Vector3 currentEulerAngles = transform.eulerAngles;
         transform.LookAt(targetTRR);
         transform.eulerAngles = new Vector3(currentEulerAngles.x, transform.eulerAngles.y, currentEulerAngles.z);
         
       
        
    }

}
