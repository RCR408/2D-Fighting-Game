using Unity.VisualScripting;
using UnityEngine;

public class GlobalMovement : MonoBehaviour
{
    public float speed;
    public float startSpeed;
    [SerializeField] private Rigidbody2D rdPlayer;
    [SerializeField] private Transform enemyPos;

    [SerializeField] private float jumpForce;
    private float startjumpForce;
    
    public bool isJumping = false;

    [SerializeField] private Animator animMan;

    private BoxCollider2D box;
    [SerializeField] private bool isDown;
    private CapsuleCollider2D capsule;

    //mirror 

    public bool mirrorFacing;
    public bool standing=false;

    public bool player1;

    //state paralysed

    public bool paralyzed = false;
    public float paralyzedTimer;
    public float paralyzedTime;

    // defence

    public bool isInDefence=false;
    public bool Ondefence;

    // Alive

    private HealthManager healthScript;

    void Start()
    {
        startSpeed = speed;
        box = GetComponent<BoxCollider2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        healthScript = GetComponent<HealthManager>();
        startjumpForce = jumpForce;
        paralyzedTime = paralyzedTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.alive)
        {
            //movement

            float moveX = 0;

            if (player1)
            {
                moveX = Input.GetAxis("Horizontal");
            }
            else
            {
                moveX = Input.GetAxis("HorizontalPlayer2");
            }

            Vector2 movementX = Vector2.right * moveX;

            rdPlayer.linearVelocity = new Vector2(moveX * speed, rdPlayer.linearVelocityY);

            if (isJumping == false && !paralyzed)
            {
                if (Input.GetButtonDown("Jump") && player1)
                {
                    rdPlayer.linearVelocity = Vector2.up * jumpForce;
                    isJumping = true;
                    animMan.SetBool("Jumping", true);
                    isDown = false;
                }
                if (Input.GetKeyDown("i") && !player1)
                {
                    rdPlayer.linearVelocity = Vector2.up * jumpForce;
                    isJumping = true;
                    animMan.SetBool("Jumping", true);
                    isDown = false;
                }
            }

            // Animation

            Animations();

            // flip
            if (transform.position.x > enemyPos.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                mirrorFacing = true;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                mirrorFacing = false;
            }

            // agacharse 
            Agacharse();

            if (standing == true)
            {
                Stop();
                jumpForce = 0;

            }
            else
            {
                speed = startSpeed;
                jumpForce = startjumpForce;
            }

            //paralisis

            OnTouch();

            // defensa

            OnDefence();
        }
        else
        {
            animMan.SetBool("DeadNigga", true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player1"))
        {
            isJumping = false;
            animMan.SetBool("Jumping", false);
        }

    }
    private void Agacharse()
    {
        if (isDown && !isJumping && !paralyzed)
        {
            animMan.SetBool("Down", true);
            speed = 0;
            box.enabled = false;
            capsule.enabled = true;
        }
        else
        {
            animMan.SetBool("Down", false);
            speed = startSpeed;
            box.enabled = true;
            capsule.enabled = false;
        }
    }

    private void Animations()
    {
        if (Input.GetKey("d") && player1 == true && !paralyzed)
        {
            if (transform.position.x < enemyPos.position.x)
            {
                animMan.SetBool("IsRunningForward", true);
                animMan.SetBool("IsRunningBelow", false);
                isInDefence = false;
                isDown = false;
            }
            else if (transform.position.x > enemyPos.position.x)
            {
                animMan.SetBool("IsRunningBelow", true);
                animMan.SetBool("IsRunningForward", false);
                isDown = false;
                isInDefence = true;
            }
        }
        else if (Input.GetKey("a") && player1 == true && !paralyzed)
        {
            if (transform.position.x > enemyPos.position.x)
            {
                animMan.SetBool("IsRunningForward", true);
                isInDefence = false;
                animMan.SetBool("IsRunningBelow", false);
                isDown = false;
            }
            else if (transform.position.x < enemyPos.position.x)
            {
                animMan.SetBool("IsRunningBelow", true);
                animMan.SetBool("IsRunningForward", false);
                isDown = false;
                isInDefence = true;
            }
        }
        else if (Input.GetKey("l") && !player1 && !paralyzed)
        {
            if (transform.position.x < enemyPos.position.x)
            {
                animMan.SetBool("IsRunningForward", true);
                animMan.SetBool("IsRunningBelow", false);
                isInDefence = false;
                isDown = false;
            }
            else if (transform.position.x > enemyPos.position.x)
            {
                animMan.SetBool("IsRunningBelow", true);
                animMan.SetBool("IsRunningForward", false);
                isInDefence = true;
                isDown = false;
            }
        }
        else if (Input.GetKey("j") && !player1 && !paralyzed)
        {
            if (transform.position.x > enemyPos.position.x)
            {
                animMan.SetBool("IsRunningForward", true);
                animMan.SetBool("IsRunningBelow", false);
                isInDefence = false;
                isDown = false;
            }
            else if (transform.position.x < enemyPos.position.x)
            {
                animMan.SetBool("IsRunningBelow", true);
                isInDefence = true;
                animMan.SetBool("IsRunningForward", false);
                isDown = false;
            }
        }
        else if (Input.GetKey("s") && player1 && !isJumping && !paralyzed)
        {
            isDown = true;
        }
        else if (Input.GetKeyUp("s") && player1 && !isJumping && !paralyzed)
        {
            isDown = false;
        }
        else if (Input.GetKey("k") && !player1 && !isJumping && !paralyzed)
        {
            isDown = true;
        }
        else if (Input.GetKeyUp("k") && !player1 && !isJumping && !paralyzed)
        {
            isDown = false;
        }
        else
        {
            animMan.SetBool("IsRunningBelow", false);
            animMan.SetBool("IsRunningForward", false);
            animMan.SetBool("Down", false);
            isInDefence = false;
        }
    }


    private void OnDefence()
    {
        if(isInDefence && Ondefence)
        {
            animMan.SetBool("IsDefence", true);
            speed = 0;
        }
        else
        {
            animMan.SetBool("IsDefence", false);
            if (standing == false)
            {
                speed = startSpeed;
            }
        }
    }
    private void OnTouch()
    {
        if (paralyzed == true)
        {
            speed = 0;
            animMan.SetBool("IsParalized", true);
            paralyzedTimer-= Time.deltaTime;

            if (paralyzedTimer <= 0)
            {
                paralyzed = false;
                animMan.SetBool("IsParalized", false);
                speed = startSpeed;
                paralyzedTimer = paralyzedTime;
            }
        }

    }
    public void Stop()
    {
       speed = 0;
    }
}
