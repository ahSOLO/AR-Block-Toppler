using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityAtoms.BaseAtoms;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] IntVariable shotsRemaining;

    [SerializeField] GameObject environmentContainer;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float ballVelocity;

    float lastFired;

    private void Start()
    {
        lastFired = Time.timeSinceLevelLoad;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        var location = context.ReadValue<Vector2>();

        if (!Helpers.IsPointerOverUIObject(location)
                && shotsRemaining.Value > 0
                && lastFired < Time.timeSinceLevelLoad - 1f)
        {
            var ball = Instantiate(ballPrefab, Camera.main.transform.position, Quaternion.identity, environmentContainer.transform);
            var target = Camera.main.ScreenToWorldPoint(new Vector3(location.x, location.y, 40f));
            var rb = ball.GetComponent<Rigidbody>();
            rb.velocity = (target - ball.transform.position).normalized * ballVelocity;

            shotsRemaining.Subtract(1);

            GameManager.instance.movingObjects.Add(rb);
            GameManager.instance.gState = GameManager.GameState.Physics;
            
            lastFired = Time.timeSinceLevelLoad;
        }
    }
}
