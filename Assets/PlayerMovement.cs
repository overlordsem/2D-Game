using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private float Movement;

    public bool inAir;

    private Rigidbody2D rb;
    private AudioSource audioSource; // Reference to AudioSource
    public AudioClip jumpSound; // Reference to the jump sound clip

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get or add the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the Rigidbody2D component exists
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component missing from this game object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement = Input.GetAxis("Horizontal");

        // Set velocity based on movement
        rb.velocity = new Vector2(speed * Movement, rb.velocity.y);

        // Check for jump input and if the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            // Apply jump force
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight));

            // Play jump sound if the AudioSource and jumpSound are set
            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound); // Play the jump sound
            }

            Debug.Log("jumping");
        }
    }

    // Detect when the player collides with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            inAir = false; // Player is grounded
        }
    }

    // Detect when the player leaves the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            inAir = true; // Player is in the air
        }
    }
}
