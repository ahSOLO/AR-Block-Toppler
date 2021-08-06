using UnityEngine;

public class Setup : IState
{

    BuildingPlacer buildingPlacer;

    public Setup(BuildingPlacer _buildingPlacer)
    {
        buildingPlacer = _buildingPlacer;
    }

    public void OnEnter()
    {
        buildingPlacer.enabled = true;
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
    }
}
