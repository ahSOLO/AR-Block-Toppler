using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] GameObject buildingPrefab;
    [SerializeField] GameObject environmentContainer;
    [SerializeField] GameObject selectionCircle;

    ARRaycastManager arRM;
    public bool buildingIsPlaced;
    ARPlaneManager arPM;

    [SerializeField] InputActionAsset inputMap;
    private InputAction click;
    private InputAction pos;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void OnEnable()
    {
        inputMap.Enable();
        
        arRM = GetComponent<ARRaycastManager>();
        arPM = GetComponent<ARPlaneManager>();
        buildingIsPlaced = false;

        click = inputMap.FindAction("Click");
        pos = inputMap.FindAction("Position");

        click.performed += PlaceBuilding;
    }

    private void Update()
    {
        if (arRM.Raycast(new Vector2(Screen.width/2, Screen.height/2), hits, TrackableType.PlaneWithinPolygon) &&
            buildingIsPlaced == false)
        {
            var hitPose = hits[0].pose;

            selectionCircle.SetActive(true);
            selectionCircle.transform.position = hitPose.position;
            selectionCircle.transform.rotation = hitPose.rotation;
        }

        else
        {
            selectionCircle.SetActive(false);
        }
    }

    public void PlaceBuilding(InputAction.CallbackContext context)
    {
        var location = pos.ReadValue<Vector2>();

        // Spawn the building prefab if raycast hits an AR plane, no building currently is placed & tap was not over a UI element
        if (arRM.Raycast(location, hits, TrackableType.PlaneWithinPolygon)
            && buildingIsPlaced == false
            && !Helpers.IsPointerOverUIObject(location))
        {
            var hitPose = hits[0].pose;

            Instantiate(buildingPrefab, hitPose.position, hitPose.rotation, environmentContainer.transform);
            arPM.enabled = false;
            
            DisableARPlanes();
            buildingIsPlaced = true;
        }
    }

    public void DisableARPlanes()
    {
        foreach (var plane in arPM.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        arPM.enabled = false;
    }

    private void OnDisable()
    {
        click.performed -= PlaceBuilding;
    }

}
