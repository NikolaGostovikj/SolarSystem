using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float selfRotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up * selfRotationSpeed * Time.deltaTime);
    }
}
