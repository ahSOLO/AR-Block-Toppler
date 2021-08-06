using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockTracker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Block")
        {
            GameManager.instance.movingObjects.Add(collision.gameObject.GetComponent<Rigidbody>());
        }
    }
}
