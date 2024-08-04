using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRepository : MonoBehaviour
{
    public static ItemRepository instance;

    [SerializeField] private Item[] items;

    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    void Awake()
    {
        //����ģʽʵ��
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        items = Resources.LoadAll<Item>("Item");
        if (items == null || items.Length == 0)
        {
            Debug.LogError("No items found to load.");
            return;
        }

        InitializeItems();
    }

    void InitializeItems()
    {
        //�ֵ��ʼ��
        foreach (Item item in items)
        {
            itemDictionary[item.itemName] = item;
        }
    }

    public Item GetItem(string itemName)
    {
        if (itemDictionary.TryGetValue(itemName, out Item item))
        {
            return item;
        }
        Debug.LogError($"Item '{itemName}' not found.");
        return null;
    }
}
