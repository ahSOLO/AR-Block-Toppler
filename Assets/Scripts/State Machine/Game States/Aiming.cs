using UnityEngine;

public class Aiming : IState
{

    BallLauncher ballLauncher;
    GameObject shotsRemainingTextObj;
    GameObject rotateRightButtonObj;
    GameObject rotateLeftButtonObj;

    public Aiming(BallLauncher _ballLauncher, GameObject _shotsRemainingTextObj, GameObject _rotateRightButtonObj, GameObject _rotateLeftButtonObj)
    {
        ballLauncher = _ballLauncher;
        shotsRemainingTextObj = _shotsRemainingTextObj;
        rotateRightButtonObj = _rotateRightButtonObj;
        rotateLeftButtonObj = _rotateLeftButtonObj;
    }

    public void OnEnter()
    {
        ballLauncher.enabled = true;
        shotsRemainingTextObj.SetActive(true);
        rotateLeftButtonObj.SetActive(true);
        rotateRightButtonObj.SetActive(true);
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
        rotateLeftButtonObj.SetActive(false);
        rotateRightButtonObj.SetActive(false);
    }
}
