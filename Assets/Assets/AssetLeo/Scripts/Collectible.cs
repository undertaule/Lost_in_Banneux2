using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    void Awake() => total++;

    
    void Update()
    {
        transform.localRotation = Quaternion.Euler(45f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collectée : " + gameObject.name);

            OnCollected?.Invoke();

            gameObject.SetActive(false);
        }
    }

}
