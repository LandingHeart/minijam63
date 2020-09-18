using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            player = GameObject.Find("Player").transform;
        }


    }

    void Update()
    {
        if (player != null)
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
