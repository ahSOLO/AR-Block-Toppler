using UnityEngine;

public class Aiming : IState
{

    BallLauncher ballLauncher;
    GameObject shotsRemainingTextObj;

    public Aiming(BallLauncher _ballLauncher, GameObject _shotsRemainingTextObj)
    {
        ballLauncher = _ballLauncher;
        shotsRemainingTextObj = _shotsRemainingTextObj;
    }

    public void OnEnter()
    {
        ballLauncher.enabled = true;
        shotsRemainingTextObj.SetActive(true);
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
        shotsRemainingTextObj.SetActive(false);
    }
}
