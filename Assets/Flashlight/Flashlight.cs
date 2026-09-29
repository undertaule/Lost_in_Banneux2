using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Flashlight : MonoBehaviour
{

    public GameObject ON;
    public GameObject OFF;

    private bool IsOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ON.SetActive(true);
       
      
    }

   
}
