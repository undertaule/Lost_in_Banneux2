using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.localRotation = Quaternion.Euler(45f, Time.time * 100f, 0);
    }
}
