using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameEventsVisualScriptingBridge: MonoBehaviour
    {
        public UnityEvent onPlayerMovementLock;

        private void OnEnable()
        {
            GameEvents.current.onPlayerMovementLock += OnPlayerMovementLockHandler;
        }

        private void OnDisable()
        {
            GameEvents.current.onPlayerMovementLock -= OnPlayerMovementLockHandler;
        }

        private void OnPlayerMovementLockHandler()
        {
            onPlayerMovementLock?.Invoke();
        }
    }
}