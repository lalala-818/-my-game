using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Item item;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player tag matched");
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                Debug.Log("Inventory found");
                inventory.AddItem(item);
                InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
                if (inventoryUI != null)
                {
                    Debug.Log("InventoryUI found");
                    inventoryUI.UpdateUI();
                }
                else
                {
                    Debug.Log("InventoryUI not found");
                }
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventory not found");
            }
          
        }
        else
        {
            Debug.Log("Player tag not matched");
        }

        // Start is called before the first frame update
        // Update is called once per frame

    }

}
