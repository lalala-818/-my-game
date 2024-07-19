using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    // Update is called once per frame
 
}
