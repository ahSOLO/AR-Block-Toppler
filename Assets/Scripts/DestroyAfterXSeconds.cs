using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXSeconds : MonoBehaviour
{
    [SerializeField] float secondsToWait;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestructionTimer(secondsToWait));
    }

    IEnumerator DestructionTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.instance.movingObjects.Remove(GetComponent<Rigidbody>());
        Destroy(gameObject);
    }
}
