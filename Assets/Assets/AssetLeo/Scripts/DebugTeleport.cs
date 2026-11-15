using UnityEngine;
using UnityEngine.InputSystem;

public class DebugTeleport : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        for (int i = 0; i < points.Length && i < 9; i++)
        {
            Key key = Key.Numpad1 + i;

            if (Keyboard.current[key].wasPressedThisFrame)
            {
                Teleport(i);
            }
        }
    }

    private void Teleport(int index)
    {
        if (points[index] == null)
            return;

        if (cc != null)
            cc.enabled = false;

        transform.position = points[index].position;

        if (cc != null)
            cc.enabled = true;
    }
}