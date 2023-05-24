using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class InventoryController : MonoBehaviour
{
    [Header("PlayerController")] public FirstPersonController PersonController;


    [Header("Inventory")] [SerializeField] private GameObject _inventory;

    public void OpenInventory()
    {
        _inventory.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        PersonController.LockCamera();
    }
}
