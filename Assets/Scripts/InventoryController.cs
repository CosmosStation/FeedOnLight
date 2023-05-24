using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [Header("Inventory")] [SerializeField] private GameObject _inventory;

    public void OpenInventory()
    {
        Debug.Log("Open Inventory");
        _inventory.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
