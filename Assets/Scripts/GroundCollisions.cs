using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisions : MonoBehaviour
{
    [SerializeField] ParticleSystem destructionParticles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Block")
        {
            Instantiate(destructionParticles, collision.transform.position, Quaternion.identity, transform);
            // GameManager.instance.UpdateScore(GameManager.instance.score + 100);
            Destroy(collision.collider.gameObject);
        }

        else if (collision.collider.tag == "Ball")
        {
            Instantiate(destructionParticles, collision.transform.position, Quaternion.identity, transform);
            Destroy(collision.collider.gameObject);
        }
    }
}
