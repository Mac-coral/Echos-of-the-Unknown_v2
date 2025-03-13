using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySystem : MonoBehaviour
{
    public List<ItemData> inventory = new List<ItemData>();
    public interactManager interact;

    public void AddItem(ItemObject item)
    {
       //retrieve data and put in inventory
    }
}
