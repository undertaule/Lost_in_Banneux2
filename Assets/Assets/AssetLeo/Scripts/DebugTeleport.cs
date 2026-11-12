using UnityEngine;
using UnityEngine.InputSystem;

public class DebugTeleport : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;

    private void Update()
    {
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
            Teleport(point1);

        if (Keyboard.current.numpad2Key.wasPressedThisFrame)
            Teleport(point2);

        if (Keyboard.current.numpad3Key.wasPressedThisFrame)
            Teleport(point3);
    }

    private void Teleport(Transform destination)
    {
        if (destination == null) return;

        CharacterController cc = GetComponent<CharacterController>();

        if (cc != null)
            cc.enabled = false;

        transform.position = destination.position;

        if (cc != null)
            cc.enabled = true;
    }
}