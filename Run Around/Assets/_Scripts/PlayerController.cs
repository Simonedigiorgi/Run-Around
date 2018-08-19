using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;
    private GameManager gameManager;

    public GameObject objectSpawner;

    public float speed;

    public bool isActive;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();

        isActive = true;
        rb.simulated = true;
	}
	
	void FixedUpdate () {

        if (isActive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                    // Fly up
                    rb.AddForce(Vector2.up * speed * Time.deltaTime);

                    // Animation flyup
                    anim.SetInteger("Fly", 1);
            }
            else
            {   // Animation flydown
                anim.SetInteger("Fly", 0);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Stop the plane
            isActive = false;

            gameManager.worldSpeed = 0;
            rb.simulated = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            // Stop the plane
            isActive = false;
        }
    }
}
