using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float speed = 2f;
    public float speedInAir = 3f;   
    public float jumpForce = 0.05f;
    public bool IsMove = false;

    float stayTime = 0f;
    float moveTime = 0f;
    int direction = 0;

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
            if (moveTime <= 0 && stayTime <= 0)
            {
                moveTime = Random.Range(1f, 3f);
                stayTime = Random.Range(1f, 3f);
                direction = Random.Range(0, 2) == 0 ? -1 : 1;
            }

            if (moveTime > 0)
            {
                moveTime -= Time.deltaTime;
                transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
                sr.flipX = direction < 0;
                IsMove = true;
            }
            else if (stayTime > 0)
            {
                stayTime -= Time.deltaTime;
                IsMove = false;
            }
        }

        anim.SetBool("IsMove", IsMove);
        anim.SetBool("OnGround", onGroundCheck.OnGround);
    }
}