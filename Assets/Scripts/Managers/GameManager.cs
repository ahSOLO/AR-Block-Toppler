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
    [SerializeField] CastleRotator castleRotator;

    [SerializeField] GameObject setupTextObj;
    [SerializeField] GameObject shotsRemainingTextObj;
    [SerializeField] GameObject scoreTextObj;
    [SerializeField] GameObject rotateRightButtonObj;
    [SerializeField] GameObject rotateLeftButtonObj;

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

        var setup = new Setup(buildingPlacer, setupTextObj);
        var aiming = new Aiming(ballLauncher, shotsRemainingTextObj, rotateRightButtonObj, rotateLeftButtonObj);
        var rotating = new Rotating();
        var resolvePhysics = new ResolvePhysics(movingObjects, scoreTextObj);

        fSM.AddTransition(setup, aiming, () => buildingPlacer.buildingIsPlaced);
        fSM.AddTransition(aiming, rotating, () => castleRotator.isRotating);
        fSM.AddTransition(rotating, aiming, () => !castleRotator.isRotating);
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
