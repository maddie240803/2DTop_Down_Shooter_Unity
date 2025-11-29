using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTriggerActivate : MonoBehaviour
{
    public GameObject objectToActivate;

    public GameObject DeactivateObject;

    public GameObject DeactivateObject2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            if ( DeactivateObject != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log("2D Object Activated!");
            }
            if (DeactivateObject != null)
            {
                DeactivateObject.SetActive(false);
                Debug.Log("2D Object Activated!");
            }
            if (DeactivateObject2 != null)
            {
                DeactivateObject2.SetActive(false);
                Debug.Log("2D Object Activated!");
            }
            Destroy(gameObject);
        }
        
    }
}