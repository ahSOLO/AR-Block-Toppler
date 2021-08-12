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
        UIController.instance.setSetupText(true, "Tap on an open, flat surface to build the castle.");
        UIController.instance.setScoreText(false);
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
        UIController.instance.setSetupText(false);
        UIController.instance.setScoreText(true, $"Current Score: {GameManager.instance.score.Value}");
    }
}
