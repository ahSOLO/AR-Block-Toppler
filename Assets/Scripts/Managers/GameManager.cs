using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StateMachine fSM;

    [SerializeField] BuildingPlacer buildingPlacer;
    [SerializeField] BallLauncher ballLauncher;

    public HashSet<Rigidbody> movingObjects = new HashSet<Rigidbody>();

    private void Awake()
    {
        // Initialize Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            enabled = false;
        }
    }

    private void Start()
    {
        fSM = new StateMachine();

        var setup = new Setup(buildingPlacer);
        var aiming = new Aiming(ballLauncher);
        var resolvePhysics = new ResolvePhysics(movingObjects);

        fSM.AddTransition(setup, aiming, () => buildingPlacer.buildingIsPlaced);
        fSM.AddTransition(aiming, resolvePhysics, () => ballLauncher.inCooldown);
        fSM.AddTransition(resolvePhysics, aiming, () => movingObjects.Count == 0);

        fSM.SetState(setup);
    }

    private void FixedUpdate()
    {
        fSM.FixedTick();
    }

    private void Update()
    {
        fSM.Tick();
    }

    private void LateUpdate()
    {
        fSM.LateTick();
    }

    public IState GetCurrentState()
    {
        return fSM._currentState;
    }
}
