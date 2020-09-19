﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nowPlatform;
    public GameObject futurePlatform;
    public bool on = false;
    

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                nowPlatform.SetActive(false);
                futurePlatform.SetActive(true);
                on = false;
            }
           
        }else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                nowPlatform.SetActive(true);
                futurePlatform.SetActive(false);
                on = true;
            }
        }
    }
}
