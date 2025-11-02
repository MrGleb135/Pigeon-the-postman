using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 5f;
    public float maxUpSpeed = 10f;
    public float maxFallSpeed = -3f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    bool isRace = false;
    bool isFlap = false;

    public OnGroundCheck OnGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        bool IsMove = Mathf.Abs(movement) > 0.01f;
        anim.SetBool("IsMove", IsMove);

        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        bool isGrounded = OnGround.OnGround;

        Vector2 velocity = rb.linearVelocity;
        if (velocity.y > maxUpSpeed)
        {
            velocity.y = maxUpSpeed;
        }
        if (velocity.y < maxFallSpeed)
        {
            velocity.y = maxFallSpeed;
        }
        rb.linearVelocity = velocity;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded && !isRace && !state.IsName("PigionRaceAnimation"))
            {
                anim.SetBool("RaceAnim", true);
                //anim.SetTrigger("RaceAnimTrigger");
                isRace = true;
            }
            else if (!isGrounded && !isFlap)
            {
                anim.SetBool("FlapAnim", true);
                isFlap = true;
            }
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
/*
        if (isRace && state.IsName("PigionRaceAnimation") && state.normalizedTime >= 1f)
        {
            anim.ResetTrigger("RaceAnimTrigger");
            anim.SetBool("FlyAnim", true);
            isRace = false;
        }
*/
        if (isRace) 
        {
            if (state.IsName("PigionRaceAnimation") && state.normalizedTime >= 1f)
            {
                anim.SetBool("RaceAnim", false);
                anim.SetBool("FlyAnim", true);
                isRace = false;
            }
        }

        if (isFlap)
        {
            if (state.IsName("PigionWingsFlapAnimation") && state.normalizedTime >= 1f)
            {
                anim.SetBool("FlapAnim", false);
                anim.SetBool("FlyAnim", true);
                isFlap = false;
            }
        }

        if ((!isGrounded) && (!isRace) && (!isFlap))
        {
            anim.SetBool("FlyAnim", true);
        }
        else
        {
            anim.SetBool("FlyAnim", false);
        }

        if (Mathf.Abs(movement) > 0.01f)
        {
            sr.flipX = movement < 0;
        }
    }
}
