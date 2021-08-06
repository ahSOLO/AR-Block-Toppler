using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class GroundCollisions : MonoBehaviour
{
    [SerializeField] ParticleSystem destructionParticles;
    [SerializeField] GameObject environmentContainer;

    [SerializeField] IntVariable score;

    private void Start()
    {
        environmentContainer = GameObject.FindGameObjectWithTag("Environment Container");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Block")
        {
            score.Add(175);
            StartCoroutine(DelayedDestroyGO(collision.gameObject, 0.3f));
        }

        else if (collision.collider.tag == "Ball")
        {
            StartCoroutine(DelayedDestroyGO(collision.gameObject, 0.4f));
        }
    }

    IEnumerator DelayedDestroyGO(GameObject go, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(destructionParticles, go.transform.position, Quaternion.identity, environmentContainer.transform);
        GameManager.instance.movingObjects.Remove(go.GetComponent<Rigidbody>());
        Destroy(go);
    }
}
