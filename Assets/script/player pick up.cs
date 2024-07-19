using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private GameObject pickedupitem;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);
        if (other.CompareTag("pickedupitem"))
        {
            if (pickedupitem == null)
            {
                Debug.Log("pickedupitem entered trigger");
                PickupItem(other.gameObject);
            }
        }

    }

    void PickupItem(GameObject item)
    {
        pickedupitem = item;
        item.SetActive(false);
    }   

    // Start is called before the first frame update
    void Start()
    {
 

        // Update is called once per frame
        void Update()
        {

        }
    }
}
