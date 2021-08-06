using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockTracker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Debugger.instance.debugText.text = (GameManager.instance.GetCurrentState().ToString());
        
        if (collision.collider.tag == "Block"
            && GameManager.instance.GetCurrentState().ToString() == "ResolvePhysics")
        {
            GameManager.instance.movingObjects.Add(collision.gameObject.GetComponent<Rigidbody>());
        }
    }
}
