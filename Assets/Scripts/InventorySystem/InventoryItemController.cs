using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    public GameObject player;

    private LightController _lightController;

    // Связать айтем в инвентаре с префабом
    public void AddItem(Item newItem, GameObject playerGameObject)
    {
        item = newItem;
        player = playerGameObject;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.ChangeColorSyringe:
                _lightController = player.GetComponent<LightController>();
                _lightController.ChangeColor(item.value);
                break;
        }

        RemoveItem();
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }
}
