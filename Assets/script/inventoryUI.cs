using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemSlotPrefab;
    public Transform itemParent;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Item item in inventory.items)
        {
            GameObject itemUI = Instantiate(itemSlotPrefab, itemParent);
            Image Icon = itemUI.transform.Find("Icon").GetComponent<Image>();
            Icon.sprite = item.itemIcon;
            Text text = itemUI.transform.Find("Quantity").GetComponent<Text>();
            text.text = item.itemQuantity.ToString();
        }
    }

    // Update is called once per frame
   
}
