using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float jumpForce;
    public float turnSpeed;
    public bool isOnGround = true;
    public float horizontalInput, verticalInput;
    public Animator characterAnimator;
    public AudioSource music;
    public AudioSource hurtNoise;
    public AudioSource keyNoise;
    public int playerLives;
    private Rigidbody rb;
    public ParticleSystem keyParticle;
    private bool youWin = false;


    public int idolTotal;
    public Text idolText;
    public Text livesText;
    public GameObject deadText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        characterAnimator = GetComponent<Animator>();

        idolText.text = "Total Idols Left: " + idolTotal.ToString();
        livesText.text = "Total Lives Left: " + playerLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (playerLives == 0)
        {
            Time.timeScale = 0;
            music.Pause();
            deadText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if(youWin)
        {
            Time.timeScale = 0;
            music.Pause();
            winText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            characterAnimator.SetTrigger("JumpTrigger");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isOnGround = false;
        }

        if(verticalInput == 0)
        {
            characterAnimator.SetFloat("Speed", 0);
        }
        else if(verticalInput > 0)
        {
            characterAnimator.SetFloat("Speed", 1);
        }
        else
        {
            characterAnimator.SetFloat("Speed", -1);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WinZone"))
        {
            youWin = true;
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            playerLives--;
            livesText.text = "Total Lives Left: " + playerLives.ToString();
            hurtNoise.Play();
        }

        if(other.gameObject.CompareTag("IdolTag"))
        {
            idolTotal--;
            idolText.text = "Total Idols Left: " + idolTotal.ToString();
            keyParticle.Play();
            keyNoise.Play();
            Destroy(other.gameObject);
        }
    }

}
