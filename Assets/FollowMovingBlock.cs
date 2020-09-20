using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovingBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkIsOnMovingBlock(){
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, layermask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.red;
        }
        else
        {
            rayColor = Color.green;
        }
        Debug.DrawRay(transform.position, Vector2.down * 1.1f, rayColor);
        // Debug.Log(raycastHit.collider.name);
        return raycastHit.collider != null;
    }
}
