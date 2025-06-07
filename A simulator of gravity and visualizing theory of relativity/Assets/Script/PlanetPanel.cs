using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetPanel : MonoBehaviour {
    public Camera arCamera;
    public GameObject planetPanel;
    public TextMeshProUGUI planetPanelTitle;
    public TextMeshProUGUI planetPanelFunFactsContent;
    public TMP_InputField massInput;
    public TMP_InputField radiusInput;

    private Planet activePlanet;

    void Update() {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                Planet planet = hit.transform.GetComponent<Planet>();
                if(planet != null) DisplayPanel(planet);
            }
        }
    }

    void DisplayPanel(Planet planet) {
        if(planetPanel.activeSelf) return;
    
        activePlanet = planet;
        activePlanet.particles.gameObject.SetActive(true);

        planetPanelTitle.text = planet.name;

        massInput.text = planet.mass.ToString();
        radiusInput.text = planet.radius.ToString();

        string[] planetFunFacts = new string[] {
            // Sun
            "1. The Sun makes up 99.8% of the mass in our solar system.\n2. It's a giant ball of hot plasma powered by nuclear fusion.\n3. Light from the Sun takes about 8 minutes to reach Earth.",
            // Mercury
            "1. Mercury is the closest planet to the Sun.\n2. A day on Mercury is longer than its year.\n3. It has almost no atmosphere, so temperatures vary wildly.",
            // Venus
            "1. Venus spins in the opposite direction of most planets.\n2. It's the hottest planet in our solar system.\n3. Venus is sometimes called Earth's sister planet due to similar size.",
            // Earth
            "1. Earth is the only planet known to support life.\n2. 70% of Earth's surface is covered by water.\n3. Earth has a powerful magnetic field that protects it from solar radiation.",
            // Mars
            "1. Mars has the tallest volcano in the solar system � Olympus Mons.\n2. It has seasons similar to Earth due to its tilted axis.\n3. Mars appears red due to iron oxide (rust) on its surface.",
            // Jupiter
            "1. Jupiter is the largest planet in our solar system.\n2. It has a Great Red Spot � a giant storm bigger than Earth.\n3. Jupiter has at least 95 moons, including Ganymede, the largest moon.",
            // Saturn
            "1. Saturn is famous for its beautiful ring system.\n2. It's less dense than water � it could float if there were a big enough ocean.\n3. Saturn has over 140 known moons.",
            // Uranus
            "1. Uranus rotates on its side, making its seasons extreme.\n2. It's the coldest planet in the solar system.\n3. Uranus was the first planet discovered with a telescope.",
            // Neptune
            "1. Neptune has the strongest winds in the solar system.\n2. It appears blue due to methane in its atmosphere.\n3. Neptune was mathematically predicted before it was observed through a telescope.",
        };

        switch(planet.name) {
            case "Sun":
                planetPanelFunFactsContent.text = planetFunFacts[0];
                break;
            case "Mercury":
                planetPanelFunFactsContent.text = planetFunFacts[1];
                break;
            case "Venus":
                planetPanelFunFactsContent.text = planetFunFacts[2];
                break;
            case "Earth":
                planetPanelFunFactsContent.text = planetFunFacts[3];
                break;
            case "Mars":
                planetPanelFunFactsContent.text = planetFunFacts[4];
                break;
            case "Jupiter":
                planetPanelFunFactsContent.text = planetFunFacts[5];
                break;
            case "Saturn":
                planetPanelFunFactsContent.text = planetFunFacts[6];
                break;
            case "Uranus":
                planetPanelFunFactsContent.text = planetFunFacts[7];
                break;
            case "Neptune":
                planetPanelFunFactsContent.text = planetFunFacts[8];
                break;
        }

        planetPanel.SetActive(true);
    }

    public void HidePanel() {
        planetPanel.SetActive(false);

        activePlanet.particles.gameObject.SetActive(false);
        activePlanet = null;

        planetPanelTitle.text = "";
        planetPanelFunFactsContent.text = "";
    }

    public void OnApply() {
        if(activePlanet == null) return;

        float newMass;
        float newRadius;

        if(float.TryParse(massInput.text, out newMass) && float.TryParse(radiusInput.text, out newRadius)) activePlanet.ApplyChanges(newMass, newRadius);
    }

    public void OnRotate() {
        if(activePlanet == null) return;
        
        string[] directionArray = { "up", "right", "forward" };
            
        int index = UnityEngine.Random.Range(0, directionArray.Length);
        string newDirection = directionArray[index];

        activePlanet.direction = newDirection;
    }
}