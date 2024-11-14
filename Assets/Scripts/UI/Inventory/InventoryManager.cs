using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Item = new List<Item>();
    public List<string> itemNames = new List<string>(); // Store item names separately
    [SerializeField] private Transform ItemContent;
    [SerializeField] private GameObject InventoryItem;
    [SerializeField] private Canvas Inventory;
    private bool isInventoryEnabled = false;
    private bool flashlightAcquired = false;
    private bool KeyAcquired = false;
    private bool Key1Acquired = false;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        OpenInventory();
    }
    public void Add(Item item)
    {
        Item.Add(item);
        itemNames.Add(item.itemName); // Store the item name

        if (itemNames.Contains("FlashLight")) // Check for the presence of "Flashlight" in the item names
        {
            flashlightAcquired = true;
        }
        if (itemNames.Contains("Key"))
        {
            KeyAcquired = true;

        }
        if (itemNames.Contains("Key1"))
        {
            Key1Acquired = true;
            Debug.Log("collected keyAcquired:" + KeyAcquired);
        }


    }



    public void Remove(Item item)
    {
        Item.Remove(item);
    }


    public void ListItem()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Item)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemNameTMP = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemNameTMP.text = item.itemName;
            itemIcon.sprite = item.icon;
            // Debug.Log(item.itemName);
            // Debug.Log(flashlightAcquired);



        }
    }

    public void OpenInventory()
    {
        if (Input.GetButtonDown("tabtab"))
        {
            isInventoryEnabled = !isInventoryEnabled;
            ListItem();
            Inventory.gameObject.SetActive(isInventoryEnabled);
            
            // Debug.Log(isInventoryEnabled);
        }
    }

    public bool IsFlashlightAcquired()
    {
        return flashlightAcquired;

    }
    public bool IsKeyAcquired()
    {
        return KeyAcquired;

    }
    public bool IsKey1Acquired()
    {
        return Key1Acquired;


    }
}


