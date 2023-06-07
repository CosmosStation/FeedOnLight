using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isLocked;

    public void UnlockDoor()
    {
        Item key = null;
        for (int i = 0; i < InventoryManager.Instance.InventoryItems.Length; i ++)
        {
            Item item = InventoryManager.Instance.InventoryItems[i].item;
            if (item.itemType == Item.ItemType.Key)
            {
                key = item;
                break;
            }
        }
        
        if (key)
        {
            isLocked = false;
            Debug.Log("Door is unlocked");
            
        } else
        {
            Debug.Log("You need key");
        }
        
    }
}
