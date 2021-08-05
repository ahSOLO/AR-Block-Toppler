using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] GameObject buildingPrefab;
    [SerializeField] GameObject environmentContainer;

    ARRaycastManager arRM;
    bool buildingIsPlaced;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        arRM = GetComponent<ARRaycastManager>();
        buildingIsPlaced = false;
    }

    public void PlaceBuilding(InputAction.CallbackContext context)
    {
        var location = context.ReadValue<Vector2>();

        if (arRM.Raycast(location, hits, TrackableType.PlaneWithinPolygon) &&
            buildingIsPlaced == false)
        {
            var hitPose = hits[0].pose;

            Instantiate(buildingPrefab, hitPose.position, hitPose.rotation, environmentContainer.transform);
            buildingIsPlaced = true;
        }
    }

}
