using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CastleRotator : MonoBehaviour
{
    [SerializeField] float rotationDuration;
    GameObject castle;
    ARSessionOrigin arSO;
    float currentPseudoRotation;

    public bool isRotating = false;

    private void Start()
    {
        arSO = GetComponent<ARSessionOrigin>();
        currentPseudoRotation = 0f;
    }

    public void RotateRight()
    {
        StartCoroutine(RotateOverTime(90f, rotationDuration));
    }

    public void RotateLeft()
    {
        StartCoroutine(RotateOverTime(-90f, rotationDuration));
    }


    IEnumerator RotateOverTime(float rotation, float duration)
    {
        if (castle == null)
            castle = GameObject.FindGameObjectWithTag("Castle");

        var t = 0f;
        var startingRotation = Quaternion.Euler(0f, currentPseudoRotation, 0f);
        var rotationTarget = Quaternion.Euler(0f, currentPseudoRotation + rotation, 0f);
        isRotating = true;

        while (t < duration)
        {
            t += Time.deltaTime;
            arSO.MakeContentAppearAt(castle.transform, castle.transform.position, Quaternion.Slerp(startingRotation, rotationTarget, t / duration));
            yield return null;
        }

        currentPseudoRotation = rotationTarget.eulerAngles.y;
        isRotating = false;
    }
}
