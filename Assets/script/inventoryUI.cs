using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemUIPrefab;
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
            GameObject itemUI = Instantiate(itemUIPrefab, itemParent);
            itemUI.GetComponent<Image>().sprite = item.itemIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
