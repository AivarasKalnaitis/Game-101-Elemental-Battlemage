using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled = false;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;

    private GameObject[] Slot;

    public GameObject slotHolder;

    void Start()
    {
        allSlots = 25;

        Slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            Slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (Slot[i].GetComponent<Slot>().item == null)
            {
                Slot[i].GetComponent<Slot>().empty = true;
            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            inventory.SetActive(false);
            Time.timeScale = 1f;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            InventoryItem item = itemPickedUp.GetComponent<InventoryItem>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
//            AddItem()
        }
    }

    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Texture2D itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (Slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<InventoryItem>().pickedUp = true;

                Slot[i].GetComponent<Slot>().item = itemObject;        
                Slot[i].GetComponent<Slot>().icon = itemIcon;
                Slot[i].GetComponent<Slot>().type = itemType;
                Slot[i].GetComponent<Slot>().ID = itemID;
                Slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = Slot[i].transform;
                itemObject.SetActive(false);

                Slot[i].GetComponent<Slot>().empty = false;

            }
        }
    }
}
