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

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    // A list that stores all detected points where AR raycast intersects with real-world objects.
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start() {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update() {
        // If SolarSystem prefab is spawned, no further actions are needed.
        if(isSolarSystemSpawned) return;

        // We use the center of the screen as the default raycast point.
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        // Here we use TrackableType.PlaneWithinPolygon because we only want to look for plane surfaces to place the solar system on.
        if(raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon)) {
            isSolarSystemSpawned = true;
        
            Pose closestPlane = hits[0].pose;

            Destroy(loading);

            // Moving the solar system slightly up the detected plane.
            Vector3 placementOffset = new Vector3(0, 0.05f, 0);
            Vector3 adjustedPosition = closestPlane.position + placementOffset;

            spawnedSolarSystem = Instantiate(solarSystem, adjustedPosition, closestPlane.rotation);

            // Size has to be adjusted for phone view, that way we avoid having too large planets that are too far away.
            float solarSystemScale = 0.1f;
            spawnedSolarSystem.transform.localScale = Vector3.one * solarSystemScale;

            DisablePlaneDetection();
        }
    }

    void DisablePlaneDetection() {
        if(planeManager != null) {
            planeManager.enabled = false;
            // There is a chance that multiple planes are detected at the time, so we will disable every plane except the first one (the one where the solar system is on).
            foreach(var plane in planeManager.trackables) plane.gameObject.SetActive(false);
        }
    }
}