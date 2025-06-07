using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotationTopDown : MonoBehaviour
{
    public GameObject obj;
    float rotationSpeed = 50f;

    
    void Update(){
        //rotates the object from top to down, we already have left to right rotation
        obj.transform.Rotate(Vector3.(1,0,0 * rotationSpeed * Time.deltaTime));
    }

}