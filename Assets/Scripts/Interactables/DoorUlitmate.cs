using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using System;

public class DoorUlitmate : MonoBehaviour
{
    // public static Action onUnlocked;

    public enum DoorTypes
    {
        None,
        Single,
        Double
    }

    public DoorTypes DoorType;
    public DOTweenAnimation[] DoorGameObjects;
    
    private bool isOpen = false;

    public void UseDoor()
    {
        Debug.Log(DoorType);
        Debug.Log(isOpen);
        foreach (var doTweenAnimation in DoorGameObjects)
        {
            if (isOpen) doTweenAnimation.DOPlayBackwards();
            else doTweenAnimation.DOPlayForward();
        }

        isOpen = !isOpen;
    }

    public void UnlockDoor()
    {

    }
}
