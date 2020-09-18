using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool faceRight;
    [SerializeField]
    private LayerMask layermask;

    //private PlayerAnimation _playerAnim;

    [SerializeField]
    private float jumpForce = 30f;

    [SerializeField]
    private bool _grounded = true;
    private BoxCollider2D boxcollider;
    public static float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGrounded());
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        CheckFaceDirection(move);

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //StartCoroutine(ResetJumpNeededRoutine());
        }
    }
    private void CheckFaceDirection(float move)
    {
        if (move > 0 && faceRight)
        {
            Flip();
        }
        else if (move < 0 && !faceRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        faceRight = !faceRight;
        // _playerSpriteFlip.flipX = !_playerSpriteFlip.flipX;
        transform.Rotate(0f, 180f, 0f);
    }

    public bool IsGrounded()
    {
        float height = .05f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxcollider.bounds.center, Vector2.down, boxcollider.bounds.extents.y + height, layermask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.red;
        }
        else
        {
            rayColor = Color.green;
        }
        Debug.DrawRay(boxcollider.bounds.center, Vector2.down * (boxcollider.bounds.extents.y + height), rayColor);
        return raycastHit.collider != null;
    }
}