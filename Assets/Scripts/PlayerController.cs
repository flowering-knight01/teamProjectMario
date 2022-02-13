using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rd2d;
    float horizontal;
    float vertical;
    public float speed;

    private float getInput;
    public float jumpForce;

    private bool onGround;

    public Transform feetPosition;

    public Transform topPosition;
    public float Radius;

    public LayerMask groundCheck;

    public bool enemyCheck;

    private float jumpCounter;
    public float jumpTime;
    private bool isJumping;

    public int scoreValue;

    public static int lives = 3;

    public GameObject coinPrefab;

    public GameObject scoreText;

    public GameObject lifeText;

    public GameObject deathBox;

    public GameObject cameraTarget;

    public GameObject timeText;

    AudioSource audioSource;

    public AudioClip music;

    public AudioClip scoreIncrease;

    private float timeStart = 300.0f;

    private float timeLeft;

    private string timeString;

    private bool flightPow = false;

    private bool timeStop = true;

    private float untilDash = 0.0f;

    private float powTimer = 30.0f;

    private bool hasPower = false;

    private int hitsLeft = 1;
	
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        cameraTarget.SetActive(true);
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();

        GetComponent<Collider2D>().enabled = true;

        //making sure the game doesn't go too far
        Application.targetFrameRate = 60;
    }

void FixedUpdate()
{
    getInput = Input.GetAxisRaw("Horizontal");

    rd2d.velocity = new Vector2(getInput * speed, rd2d.velocity.y);

    scoreText.GetComponent<Text>().text = "Coins: " + scoreValue;
    lifeText.GetComponent<Text>().text = "Lives: " + lives;
    timeText.GetComponent<Text>().text = "Time Left: " + timeLeft;
}
    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(feetPosition.position, Radius, groundCheck);

        if(onGround == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpCounter = jumpTime;
            rd2d.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if(Input.GetKey(KeyCode.W))
        {
            if(jumpCounter > 0 && isJumping == true)
            {
                rd2d.velocity = Vector2.up * jumpForce;
                jumpCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

        if(timeStop == true)
        {
            timeLeft = timeStart -= Time.deltaTime;
            timeString = timeLeft.ToString();
        }
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8;

            //start timer
            untilDash += Time.deltaTime;
            //Debug.Log(untilDash);
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            untilDash = 0.0f;

            speed = 6.5f;
        }

        if(flightPow)
        {
            powTimer -= Time.deltaTime;
            //Debug.Log(powTimer);

            if(powTimer <= 0.0f || hitsLeft < 2)
            {
                hitsLeft = 1;
                flightPow = false;
                hasPower = false;
            }
        }

        if(rd2d.velocity.x == 8 && (untilDash >= 2.5f))
        {
            //Debug.Log("speed is 8");
            //Debug.Log("dashing");
            
            //flight, but it only works when moving right
            //something to do with the velocity
            if(Input.GetKey(KeyCode.W) && flightPow == true && powTimer > 0.0f)
            {
                rd2d.velocity = Vector2.up * jumpForce;
            }
        }

        //Debug.Log(hitsLeft);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Pickups coin = other.gameObject.GetComponent<Pickups>();
        if (coin != null)
        {
            audioSource.PlayOneShot(scoreIncrease);
            scoreValue += 1;
        }

        Victory win = other.gameObject.GetComponent<Victory>();

        DeathBoxScript death = other.gameObject.GetComponent<DeathBoxScript>();
        
        if(other.tag == "enemyDbox")
        {
            //Debug.Log("thing happened");
            if(hitsLeft > 1)
            {
                //if hit when 
                hitsLeft = 1;
            }
            else
            {
                hitsLeft -= 1;
            }
        }
        
        if(hitsLeft <= 0 || other.tag == "deathBox")
        {
            if (death != null)
            {
                death.deathCheck = true;
                speed = 0;
                jumpForce = 0;
                Destroy(cameraTarget);
                lives-= 1;
                CameraScript.speed = 0;
                GetComponent<Collider2D>().enabled = false;

                //GetComponent<SpriteRenderer>().flipY = true;

                //death movement
                Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
                transform.position += movement * Time.deltaTime;

                //stops the timer when dead
                timeStop = false;
            }
        }

        if (win != null)
        {
            win.winCheck = true;
			speed = 0;
            jumpForce = 0;
            CameraScript.speed = 0;

            //stops the timer when win
            timeStop = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        //DeathBoxScript death = other.gameObject.GetComponent<DeathBoxScript>();

        Debug.Log(other.gameObject.tag);

        Debug.Log(hitsLeft);

        /*
        if(other.gameObject.tag == "enemy")
        {
            Debug.Log("from player: hit enemy " + hitsLeft +" left");
        }
        */

        if(other.gameObject.tag == "powerUp1")
        {
            //wings, which are on a timer like the original
            Debug.Log("from player: power up hit");

            hasPower = true;

            powTimer = 30.0f;

            powerUp();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "powerUp2")
        {
            //1up
            lives += 1;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "powerUp3")
        {
            //mushroom
            hitsLeft = 2;
            Destroy(other.gameObject);
        }
    }

    private void powerUp()
    {
        if(hasPower == true)
        {
            flightPow = true;
            Debug.Log("powerUp enabled");
            hitsLeft = 2;
        }
        
        if(powTimer <= 0.0f)
        {
            hasPower = false;
            flightPow = false;
        }
    }
}