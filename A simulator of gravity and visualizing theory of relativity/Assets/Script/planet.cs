using UnityEngine;

public class Planet : MonoBehaviour
{
    public string name;

    public float mass = 1000f; //measure mass
    public float radius = 5f;
    
    public float gravityForce(Planet planet){
        float G = 0.6674f;
        float distance = Vector3.Distance(transform.position, planet.transform.position);//one is the other planet, other is this
        //Eucledian distance between two planets d = sqrt( (x2-x1)^2 + (y2-y1)^2 + (z2-z1)^2 )
        if(distance == 0f){
            return 0f; //division by 0
        }

        //formula for force -> F = G * (m1 * m2) / r^2 
        float force = G * (mass * planet.mass) / (distance * distance);
        return force;
    }



     void Start(){
        //scaling and adding rigidbody
        transform.localScale = Vector3.one * radius * 2f;
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = mass; //setting mass
        rb.useGravity = false; 
        rb.isKinematic = false; //disable only gravity, false to use unity collision    


        // this is for the collisoon
        gameObject.AddComponent<SphereCollider>();

    }





}