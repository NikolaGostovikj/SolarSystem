using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArPlaceObject : MonoBehaviour
{
    public GameObject solarSystem;
    private GameObject spawnedSolarSystem;

    private ARRaycastManager raycastManager;
    // Stores all successful AR hits.
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // solarSystem has already been spawned.
        if(spawnedSolarSystem != null) return;

        if(Input.touchCount > 0) {
            // If the screen was tocuhed, we take the first touch and store it inside touch variable.
            Touch touch = Input.GetTouch(0);

            // We're checking if raycast happens.
            // User has to tap on some plane.
            if(raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon)) {
                // Position of the first hit is stored inside hitPose.
                Pose hitPose = hits[0].pose;
                spawnedSolarSystem = Instantiate(solarSystem, hitPose.position, hitPose.rotation);
            }
        }
    }
}