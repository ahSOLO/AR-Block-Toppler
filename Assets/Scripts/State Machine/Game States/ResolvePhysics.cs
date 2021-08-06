using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ResolvePhysics : IState
{
    HashSet<Rigidbody> movingObjects;
    GameObject scoreTextObj;

    public ResolvePhysics(HashSet<Rigidbody> _movingObjects, GameObject _scoreTextObj)
    {
        movingObjects = _movingObjects;
        scoreTextObj = _scoreTextObj;
    }

    public void OnEnter()
    {
        scoreTextObj.SetActive(true);
    }

    public void FixedTick()
    {
        
    }

    public void Tick()
    {
        
    }

    public void LateTick()
    {
        movingObjects.RemoveWhere(rb => rb.velocity.sqrMagnitude < 0.1f);
    }

    public void OnExit()
    {
        scoreTextObj.SetActive(false);
    }
}
