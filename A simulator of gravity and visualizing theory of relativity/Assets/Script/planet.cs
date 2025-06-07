using UnityEngine;

public class Planet : MonoBehaviour
{
    public string name;
    public ParticleSystem particles;

    public float mass = 1000f; //measure mass
    public float radius;

    private float selfRotationSpeed = 50f;
    
    public string direction = "up";
    private Vector3 vectorDirection;
    
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

    public void ApplyChanges(float newMass, float newRadius) {
        mass = newMass;
        radius = newRadius;

        transform.localScale = Vector3.one * radius * 2f;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.mass = mass;
    }

    void Start(){
        radius = transform.localScale.x / 2f;
        vectorDirection = direction == "up" ? Vector3.up : direction == "right" ? Vector3.right : Vector3.forward;
    }

    void Update() {
        vectorDirection = direction == "up" ? Vector3.up : direction == "right" ? Vector3.right : Vector3.forward;
        transform.Rotate(vectorDirection * selfRotationSpeed * Time.deltaTime);
    }
}