using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Vector2 move;
    public float jumpVelocity = 10000f;
    bool grounded;
    Collider2D getTag;
    public LayerMask groundLayer;
    public Animator anim;
    public float speed = 10f;
    

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        IsGrounded();


        if (Input.GetButtonDown("Jump") && grounded)
        {
            //rb2d.transform.position += new Vector3(0, jumpVelocity*Time.deltaTime, 0);
            rb2d.AddForce(new Vector2(0, jumpVelocity * Time.deltaTime));
        }
        rb2d.position += move * speed * Time.deltaTime;
        if (move.x > 0 && transform.localScale.x < 0 || move.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        anim.SetFloat("xVelocity", Mathf.Abs(move.x));
        anim.SetBool("grounded", grounded);
	}

    void IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position,direction, Color.green);
        grounded = hit.collider != null;
        Debug.Log(grounded);

    }
}
