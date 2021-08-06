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
    public bool inCooldown = false;
    float cooldownTime = 0.5f;

    [SerializeField] InputActionAsset inputMap;
    private InputAction click;
    private InputAction pos;

    float lastFired;

    private void OnEnable()
    {
        inputMap.Enable();

        lastFired = Time.timeSinceLevelLoad;

        click = inputMap.FindAction("Click");
        pos = inputMap.FindAction("Position");

        click.performed += Fire;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        var location = pos.ReadValue<Vector2>();

        if (!Helpers.IsPointerOverUIObject(location)
                && shotsRemaining.Value > 0
                && lastFired < Time.timeSinceLevelLoad - cooldownTime)
        {
            var ball = Instantiate(ballPrefab, Camera.main.transform.position, Quaternion.identity, environmentContainer.transform);
            var target = Camera.main.ScreenToWorldPoint(new Vector3(location.x, location.y, 40f));
            var rb = ball.GetComponent<Rigidbody>();
            rb.velocity = (target - ball.transform.position).normalized * ballVelocity;

            shotsRemaining.Subtract(1);
            GameManager.instance.movingObjects.Add(rb);

            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        inCooldown = false;
    }

    private void OnDisable()
    {
        click.performed -= Fire;
    }
}
