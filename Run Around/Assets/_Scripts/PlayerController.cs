using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;

    public float speed;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.simulated)
            {
                // Fly up
                rb.AddForce(Vector2.up * speed * Time.deltaTime);

                // Animation flyup
                anim.SetInteger("Fly", 1);
            }
        }
        else
        {   // Animation flydown
            anim.SetInteger("Fly", 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Stop the plane
            rb.simulated = false;
        }
    }
}
