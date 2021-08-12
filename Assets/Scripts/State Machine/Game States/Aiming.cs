using UnityEngine;

public class Aiming : IState
{

    BallLauncher ballLauncher;

    public Aiming(BallLauncher _ballLauncher)
    {
        ballLauncher = _ballLauncher;
    }

    public void OnEnter()
    {
        ballLauncher.enabled = true;
        UIController.instance.setShotsRemainingText(true);
        UIController.instance.toggleRotationButtons(true);
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
        ballLauncher.enabled = false;
        UIController.instance.setShotsRemainingText(false);
        UIController.instance.toggleRotationButtons(false);
    }
}
