using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isLocked;

   /* public void OnEnable()
    {
        LockedEvent.onUnlocked += UnlockDoor;
    }
*/
    public void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("Door is unlocked");
    }
}
