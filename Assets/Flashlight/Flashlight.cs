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
        ON.SetActive(false);
        OFF.SetActive(true);
        IsOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsOn)
            {
                ON.SetActive(false);
                OFF.SetActive(true);
            }

            if (!IsOn)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
            }


            IsOn = !IsOn;
        }
        
    }
}
