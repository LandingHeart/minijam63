using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovingBlock : MonoBehaviour
{
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIsOnMovingBlock();
    }

    void checkIsOnMovingBlock(){
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            if(raycastHit.collider.tag == "MovingBlock"){
                gameObject.transform.parent = raycastHit.collider.gameObject.transform;
            }
            rayColor = Color.red;
        }
        else
        {
            gameObject.transform.parent = null;
            rayColor = Color.green;
        }
        Debug.DrawRay(transform.position, Vector2.down * 1.1f, rayColor);
    }
}
