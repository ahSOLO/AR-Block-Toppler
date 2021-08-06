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
    }
}
