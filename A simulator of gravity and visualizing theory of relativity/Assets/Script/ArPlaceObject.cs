using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArPlaceObject : MonoBehaviour {
    public GameObject solarSystem;
    // spawnedSolarSystem is the actual game object that is placed into the AR video, it is the copy of the prefab SolarSystem.
    private GameObject spawnedSolarSystem;
    private bool isSolarSystemSpawned = false;

    public GameObject loading;
    private GameObject spawnedLoading;

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    // A list that stores all detected points where AR raycast intersects with real-world objects.
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start() {
        spawnedLoading = Instantiate(loading);

        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update() {
        // If SolarSystem prefab is spawned, no further actions are needed.
        if(isSolarSystemSpawned) return;

        // We use the center of the screen as the default raycast point.
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            // Here we use TrackableType.PlaneWithinPolygon because we only want to look for plane surfaces to place the solar system on.
            if(raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) {
                isSolarSystemSpawned = true;
                Destroy(spawnedLoading);
        
                Pose closestPlane = hits[0].pose;

                // Moving the solar system slightly up the detected plane.
                Vector3 placementOffset = new Vector3(0, 0.05f, 0);
                Vector3 adjustedPosition = closestPlane.position + placementOffset;

                spawnedSolarSystem = Instantiate(solarSystem, adjustedPosition, closestPlane.rotation);

                // Size has to be adjusted for phone view, that way we avoid having too large planets that are too far away.
                float solarSystemScale = 0.1f;
                spawnedSolarSystem.transform.localScale = Vector3.one * solarSystemScale;

                UpdatePlaneDetection(false);
            }
        }
    }

    void UpdatePlaneDetection(bool status) {
        if(planeManager != null) {
            planeManager.enabled = status;
            foreach(var plane in planeManager.trackables) plane.gameObject.SetActive(status);
        }
    }

    public void OnRefresh() {
        if(isSolarSystemSpawned) {
            Destroy(spawnedSolarSystem);
            isSolarSystemSpawned = false;

            spawnedLoading = Instantiate(loading);

            UpdatePlaneDetection(true);
            hits.Clear();
        }
    }
}