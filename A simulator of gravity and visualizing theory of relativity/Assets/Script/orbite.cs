using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float orbitSpeed = 20f;
    public Vector3 orbitAxis = Vector3.up;

    void Update()
    {
        transform.Rotate(orbitAxis, orbitSpeed * Time.deltaTime);
    }
}
