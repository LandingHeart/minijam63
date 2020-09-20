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

    public GameObject nowBackgroundmap;
    public GameObject futureBackgroundmap;

    public GameObject nowCloud;
    public GameObject futureClound;

    public DebrisScript debris;

    void Update()
    {

        if (clear == false)
        {
            if (on)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nowPlatform.SetActive(true);
                    nowBackgroundmap.SetActive(true);
                    futureBackgroundmap.SetActive(false);
                    futurePlatform.SetActive(false);
                    // nowCloud.SetActive(true);
                    // futureClound.SetActive(false);

                    debris.StopDebris();

                    on = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nowPlatform.SetActive(false);
                    nowBackgroundmap.SetActive(false);
                    futureBackgroundmap.SetActive(true);
                    futurePlatform.SetActive(true);
                    // nowCloud.SetActive(false);
                    // futureClound.SetActive(true);
                    debris.InitDebris();
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
                    nowBackgroundmap.SetActive(true);
                    futureBackgroundmap.SetActive(false);
                    futurePlatform1.SetActive(false);
                    on = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nowPlatform1.SetActive(false);
                    nowBackgroundmap.SetActive(false);
                    futureBackgroundmap.SetActive(true);
                    futurePlatform1.SetActive(true);
                    on = true;
                }
            }
        }
    }
}
