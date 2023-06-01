using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class InventoryController : MonoBehaviour
{
    [Header("PlayerController")] public FirstPersonController PersonController;
    [Header("InventoryManager")] public InventoryManager InventoryManager;

    [Header("Inventory")] [SerializeField] private GameObject _inventory;

    public void OpenInventory()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        PersonController.LockCamera();

        _inventory.SetActive(true);
        InventoryManager.ListItems();
    }
}
