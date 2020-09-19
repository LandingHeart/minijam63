using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject futurePlatform;
    public GameObject nowPlatform;
    public bool on = false;
    

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                futurePlatform.SetActive(false);
                nowPlatform.SetActive(true);
                on = false;
            }
           
        }else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                futurePlatform.SetActive(true);
                nowPlatform.SetActive(false);
                on = true;
            }
        }
    }
}
