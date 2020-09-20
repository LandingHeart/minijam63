using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded()){
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector3(0,0,0);
        }
        else{
            rb.gravityScale = 3;
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.red;
             Debug.Log(raycastHit.collider.name);
        }
        else
        {
            rayColor = Color.green;
        }
        Debug.DrawRay(transform.position, Vector2.down * 1f, rayColor);
       
        return raycastHit.collider != null;
    }
}
