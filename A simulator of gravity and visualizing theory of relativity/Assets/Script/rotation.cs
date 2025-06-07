using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Update is called once per frame
    public float selfRotationSpeed = 50f;
    
    public string direction = "up";
    private Vector3 vectorDirection;

    void Start() {
        vectorDirection = direction == "up" ? Vector3.up : direction == "right" ? Vector3.right : Vector3.forward;
    }

    void Update() {
        vectorDirection = direction == "up" ? Vector3.up : direction == "right" ? Vector3.right : Vector3.forward;
        transform.Rotate(vectorDirection * selfRotationSpeed * Time.deltaTime);
    }
}