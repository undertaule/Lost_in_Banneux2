using UnityEngine;

public class LeverReset : MonoBehaviour
{
    [SerializeField] private ResettableObject[] objectsToReset;

    public void ActivateLever()
    {
        foreach (ResettableObject obj in objectsToReset)
        {
            if (obj != null)
                obj.ResetObject();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateLever();
        }
    }
}