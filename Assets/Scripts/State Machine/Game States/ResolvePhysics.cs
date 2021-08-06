using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ResolvePhysics : IState
{
    HashSet<Rigidbody> movingObjects;

    public ResolvePhysics(HashSet<Rigidbody> _movingObjects)
    {
        movingObjects = _movingObjects;
    }

    public void OnEnter()
    {

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

    }
}
