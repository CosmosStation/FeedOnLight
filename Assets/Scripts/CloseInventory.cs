using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CloseInventory : MonoBehaviour
{
    [Header("PlayerController")] public FirstPersonController PersonController;

    [Header("Inventory")] [SerializeField] private GameObject _inventory;

    public void CloseInventoryWindow()
    {
        _inventory.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PersonController.UnlockCamera();

        InventoryManager.Instance.CleanInventoryList();
    }

}
