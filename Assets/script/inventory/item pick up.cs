using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Item item;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {

                Inventory.instance.AddItem(item.itemId, item, 1) ;
               
              
                Destroy(gameObject);
            }
       
        }

    }

}
