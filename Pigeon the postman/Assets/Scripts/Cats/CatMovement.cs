using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float speed = 2f;
    public float speedInAir = 3f;   
    public float jumpForce = 0.5f;
    public bool IsMove = false;

    public GameObject player;

    public OnGroundCheckForCats onGroundCheck;
    public VisionZone visionZone;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        bool catSeePlayer = visionZone.catSeePlayer;

        float turn = (transform.position.x - player.transform.position.x) < 0 ? 1 : -1;
        if (catSeePlayer)
        {
            if(onGroundCheck.OnGround)
            {
                transform.position += new Vector3(turn, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(turn, 0, 0) * speedInAir * Time.deltaTime;
            }
            sr.flipX = turn >= 0 ? false : true;
            IsMove = true;
            /*
            if(onGroundCheck.OnGround && Mathf.Abs(transform.position.x - player.transform.position.x) <= 2f && Mathf.Abs(transform.position.x - player.transform.position.x) >= 1f)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                anim.SetTrigger("IsJump");
            }*/
        }
        if (!catSeePlayer)
        {
            IsMove = false;
        }

        anim.SetBool("IsMove", IsMove);
        anim.SetBool("OnGround", onGroundCheck.OnGround);
    }
}