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

    public GameObject enemyHead;

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

    private string timeSrting;

    private bool flightPow = false;

    private bool timeStop = true;
	
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
            timeSrting = timeLeft.ToString();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Pickups coin = other.gameObject.GetComponent<Pickups>();
        if (coin != null)
        {
            audioSource.PlayOneShot(scoreIncrease);
            scoreValue += 1;
        }
		
        DeathBoxScript death = other.gameObject.GetComponent<DeathBoxScript>();

        Victory win = other.gameObject.GetComponent<Victory>();

        if (death != null)
        {
            death.deathCheck = true;
            speed = 0;
            jumpForce = 0;
            Destroy(cameraTarget);
            lives-= 1;
            CameraScript.speed = 0;
            GetComponent<Collider2D>().enabled = false;

            GetComponent<SpriteRenderer>().flipY = true;

            Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
            transform.position += movement * Time.deltaTime;

            timeStop = false;
        }

        if (win != null)
        {
            win.winCheck = true;
			speed = 0;
            jumpForce = 0;
            CameraScript.speed = 0;
            timeStop = false;
        }

        /*
        if (death == null && win == null)
        {
            scoreValue += 1;
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Debug.Log("from player: hit enemy");
        }

        if(other.gameObject.tag == "powerUp1")
        {
            Debug.Log("from player: power up hit");
            powerUp();
            Destroy(other.gameObject);
        }
    }

    private void powerUp()
    {
        Debug.Log("powerUp enabled");
    }
}