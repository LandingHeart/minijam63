using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    [SerializeField]
    private Transform cachePlayerPostion;

    void Start()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.position = cachePlayerPostion.position;
        }
    }
}
