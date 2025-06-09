using UnityEngine;
using System.Collections.Generic;

public class Planet : MonoBehaviour {
    public string name;
    public ParticleSystem particles;

    public float radius;
    public Vector3 position;

    public string direction = "up";
    private float selfRotationSpeed = 25f;
    
    public string GravityForce(Planet planet, string[] solarSystemPlanets) {
        float G = 0.6674f;
        string result = "Gravitational forces from " + planet.name + ":\n";

        Dictionary<string, float> masses = new Dictionary<string, float> {
            { "Sun", 1988500f },
            { "Mercury", 0.330f },
            { "Venus", 4.87f },
            { "Earth", 5.97f },
            { "Mars", 0.642f },
            { "Jupiter", 1898f },
            { "Saturn", 568f },
            { "Uranus", 86.8f },
            { "Neptune", 102f }
        };

        Dictionary<string, float> positions = new Dictionary<string, float> {
            { "Sun", 0f },
            { "Mercury", 57.9f },
            { "Venus", 108.2f },
            { "Earth", 149.6f },
            { "Mars", 227.9f },
            { "Jupiter", 778.3f },
            { "Saturn", 1427f },
            { "Uranus", 2871f },
            { "Neptune", 4497.1f }
        };

        foreach (string solarSystemPlanet in solarSystemPlanets) {
            if (solarSystemPlanet == planet.name) continue;

            float distance = Mathf.Abs(positions[planet.name] - positions[solarSystemPlanet]);
            float force = G * (masses[planet.name] * masses[solarSystemPlanet]) / (distance * distance);

            result += $"- {solarSystemPlanet}: {force:F4} units\n";
        }

        return result;
    }

    public void ApplyChanges(float newRadius) {
        radius = newRadius;
        transform.localScale = Vector3.one * radius * 2f;
    }

    void Start() {
        radius = transform.localScale.x / 2f;
        position = direction == "up" ? Vector3.up : direction == "right" ? Vector3.right : Vector3.forward;
    }

    void Update() {
        position = direction == "up" ? Vector3.up : direction == "right" ? Vector3.right : Vector3.forward;
        transform.Rotate(position * selfRotationSpeed * Time.deltaTime);
    }
}