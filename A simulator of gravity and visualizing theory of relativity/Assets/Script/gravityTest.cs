using UnityEngine;

public class GravityTest : MonoBehaviour
{
    //Shows the force between planets in console
    //need to create an empty game object, add this script, then add the planets in
    
    public Planet planetA;
    public Planet planetB;

    void Start()
    {
        float force = planetA.gravityForce(planetB);
        Debug.Log("Gravitational Force between planets: " + force);
    }
}
