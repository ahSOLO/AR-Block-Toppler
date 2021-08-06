using UnityEngine;

public class Setup : IState
{

    BuildingPlacer buildingPlacer;
    GameObject setupTextObj;

    public Setup(BuildingPlacer _buildingPlacer, GameObject _setupTextObj)
    {
        buildingPlacer = _buildingPlacer;
        setupTextObj = _setupTextObj;
    }

    public void OnEnter()
    {
        buildingPlacer.enabled = true;
        setupTextObj.SetActive(true);
    }

    public void FixedTick()
    {

    }

    public void Tick()
    {

    }

    public void LateTick()
    {

    }

    public void OnExit()
    {
        buildingPlacer.enabled = false;
        setupTextObj.SetActive(false);
    }
}
