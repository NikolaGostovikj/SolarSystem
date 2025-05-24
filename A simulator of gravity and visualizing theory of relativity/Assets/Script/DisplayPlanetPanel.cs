using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayPlanetPanel : MonoBehaviour {
    public Camera arCamera;
    public GameObject planetPanel;
    public TextMeshProUGUI planetPanelTitle;

    void Update() {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                Planet planet = hit.transform.GetComponent<Planet>();
                if(planet != null) DisplayPanel(planet.name);
            }
        }
    }

    void DisplayPanel(string planetName) {
        planetPanelTitle.text = planetName;
        planetPanel.SetActive(true);
    }
}