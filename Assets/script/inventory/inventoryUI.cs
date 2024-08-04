using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform itemParent;
    int index = 0;
    public float itemSlotWidth = 80f;

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
        Dictionary<int, Item> items = Inventory.instance.GetAllItems();
        foreach (var kvp in items)
        {
            int itemID = kvp.Key;
            Item item = kvp.Value;
            GameObject itemUI = Instantiate(itemSlotPrefab, itemParent);
            //实现物品排序
            RectTransform rectTransform = itemUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(index * itemSlotWidth, 0);
            index++;
            //实现物品及其数量的显示
            Image Icon = itemUI.transform.Find("Icon").GetComponent<Image>();
            Icon.sprite = item.itemIcon;
            Text text = itemUI.transform.Find("Quantity").GetComponent<Text>();
            text.text = item.itemQuantity.ToString();
            Debug.Log(item.itemName + " " + item.itemQuantity.ToString());
            
            
        }
    }

   
}
