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
    [SerializeField] LayerMask treeLayer;
    [SerializeField] LayerMask plantLayer;
    public float distance;
    bool isClimbing = false;
    float climb;

    public Transform grabDetect;
    public Transform boxHolder;
    public float holdRayDist;
    bool isHolding = false;
    bool isHoldingSpecial = false;

    //private PlayerAnimation _playerAnim;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private bool _grounded = true;
    private BoxCollider2D boxcollider;
    public static float damage = 10f;
    public Transform jumpPoint;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(IsGrounded());
        Movement();
    }

    public bool isHoldingItem(){
        if(isHoldingSpecialItem()) return false;  // if holding special, then it means not holding normal
        return isHolding;
    }

    public bool isHoldingSpecialItem(){
        return isHoldingSpecial;
    }

    public void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        CheckFaceDirection(move);

        rb.velocity = new Vector2(move * speed, rb.velocity.y);



        if (IsGrounded())
        {
            canJump = true;
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //StartCoroutine(ResetJumpNeededRoutine());
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            if(canJump){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            canJump = false;
            
        }

        

        checkHoldItem();

        checkClimbing();


    }

    void checkHoldItem(){
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, holdRayDist, plantLayer);
        if(grabCheck.collider != null){
            // Debug.Log("seed");
            if(!isHolding && Input.GetKeyDown(KeyCode.E)){
                ToggleTimeScript toggleTimeScript = GameObject.Find("GameMaster").GetComponent<ToggleTimeScript>();
                if(toggleTimeScript && !toggleTimeScript.isTree()){
                    if(grabCheck.collider.tag == "specialPlant"){
                        isHoldingSpecial = true;
                    }
                    isHolding = true;
                    grabCheck.collider.gameObject.transform.parent = boxHolder;
                    grabCheck.collider.gameObject.transform.position = boxHolder.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                
            }else if(isHolding && Input.GetKeyDown(KeyCode.E)){
                ToggleTimeScript toggleTimeScript = GameObject.Find("GameMaster").GetComponent<ToggleTimeScript>();
                if(toggleTimeScript && !toggleTimeScript.isTree()){
                    if(grabCheck.collider.tag == "specialPlant"){
                        isHoldingSpecial = false;
                    }
                    isHolding = false;
                    grabCheck.collider.gameObject.transform.parent = null;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }
    }

    void checkClimbing(){
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, treeLayer);
        if(hitInfo.collider != null){
            // Debug.Log("tree");
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                isClimbing = true;
            }
        }else{
            isClimbing = false;
        }

        if(isClimbing){
            climb = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, climb * speed);
            rb.gravityScale = 0;
        }else{
            rb.gravityScale = 5;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}