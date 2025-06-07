using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotationSideWays : MonoBehaviour
{
    float rotationSpeed = 50f;
    
    //Skewed rotation
    void Update(){
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}
