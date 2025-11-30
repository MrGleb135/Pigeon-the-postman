using NUnit.Framework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float speedInAir = 5f;   
    public float jumpForce = 5f;
    public float maxUpSpeed = 10f;
    public float maxFallSpeed = -3f;
    public float characterTilt = 0f;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    bool isRace = false;
    bool isFlap = false;

    public OnGroundCheck OnGround;
    public EnergyCount energyCount;
    public CameraUpgread сameraUpgread;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        bool isUpgreadMenu = сameraUpgread.upgreadMenu;

        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        bool isGrounded = OnGround.OnGround;

        int energy = energyCount.energy;

        if (!isUpgreadMenu)
        {
            float movement = Input.GetAxis("Horizontal");
            if (!isGrounded)
            {
                float turn = sr.flipX ? -1f : 1f;
                transform.position += new Vector3(turn, 0, 0) * speedInAir * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;
            }


            bool IsMove = Mathf.Abs(movement) > 0.01f;
            anim.SetBool("IsMove", IsMove);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                maxFallSpeed = -15f;
                if (!isGrounded)
                {
                    characterTilt = sr.flipX ? 30f : -30f;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                maxFallSpeed = -3f;
                characterTilt = 0f;
            }
            if (isGrounded)
            {
                characterTilt = 0f;
            }
            transform.localEulerAngles = new Vector3(0, 0, characterTilt);

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

            if (Input.GetKeyDown(KeyCode.Space) && energy > 0)
            {
                if (isGrounded && !isRace && !state.IsName("PigionRaceAnimation"))
                {
                    anim.SetBool("RaceAnim", true);
                    isRace = true;
                }
                else if (!isGrounded && !isFlap)
                {
                    anim.SetBool("FlapAnim", true);
                    isFlap = true;
                }
                energyCount.energy = energyCount.energy - 10;
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                SoundVolume.instance.PlayRandomSound();
            }

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
}