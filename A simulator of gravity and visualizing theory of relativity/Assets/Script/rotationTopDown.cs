using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotationTopDown : MonoBehaviour
{
    public GameObject obj;
    float rotationSpeed = 50f;

    
    void Update(){
        //Roll
        obj.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
    }

}