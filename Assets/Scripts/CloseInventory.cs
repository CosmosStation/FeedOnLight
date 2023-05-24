using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    [Header("Inventory")] [SerializeField] private GameObject _inventory;

    public void CloseInventoryWindow()
    {
        Debug.Log("Close Inventory");
        _inventory.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
   
}
