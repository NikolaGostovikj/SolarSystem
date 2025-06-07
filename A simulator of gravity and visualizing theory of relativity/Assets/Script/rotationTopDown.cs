using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotationTopDown : MonoBehaviour
{
    float rotationSpeed = 50f;

    
    void Update(){
        //Roll, top to bottom
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
    }

}