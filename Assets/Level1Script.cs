using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    // Start is called before the first frame update
    public bool on = false;
    public GameObject nowPlatform;
    public GameObject futurePlatform;

    public static bool clear;
    public GameObject nowPlatform1;
    public GameObject futurePlatform1;




    // Update is called once per frame
    void Update()
    {

        if (clear == false)
        {
            if (on)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nowPlatform.SetActive(true);
                    futurePlatform.SetActive(false);
                    on = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nowPlatform.SetActive(false);
                    futurePlatform.SetActive(true);
                    on = true;
                }
            }
        }
        else
        {
            if (on)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nowPlatform1.SetActive(true);
                    futurePlatform1.SetActive(false);
                    on = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nowPlatform1.SetActive(false);
                    futurePlatform1.SetActive(true);
                    on = true;
                }
            }
        }
    }
}
