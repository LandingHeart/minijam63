using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seed;
    public GameObject tree;
    public bool on = false;
    Rigidbody2D rb;
    Collider2D collider;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                seed.SetActive(false);
                tree.SetActive(true);
                on = false;
                rb.velocity = Vector3.zero;
                rb.isKinematic = true; // Deactivated
                collider.enabled = false;
            }
           
        }else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                seed.SetActive(true);
                tree.SetActive(false);
                on = true;
                rb.isKinematic = false; // Activated
                collider.enabled = true;
            }
        }
    }
}
