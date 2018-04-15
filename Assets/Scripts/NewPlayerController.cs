using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Vector2 move;
    public float jumpVelocity = 10000f;
    bool grounded;
    public LayerMask groundLayer;
    public LayerMask projectileLayer;
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

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
    //    {
    //        grounded = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    grounded = false;
    //}

    void IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;
        float projectileDistance = 2f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        RaycastHit2D projectileHit = Physics2D.Raycast(position, direction, projectileDistance, projectileLayer);
        RaycastHit2D projectileHitLeft = Physics2D.Raycast(position +new Vector2(-1,0), direction, projectileDistance, projectileLayer);
        RaycastHit2D projectileHitRight = Physics2D.Raycast(position + new Vector2(1, 0), direction, projectileDistance, projectileLayer);
        //Debug.DrawRay(position,direction, Color.green);
        grounded = hit.collider != null || projectileHit.collider != null || projectileHitLeft.collider != null || projectileHitRight.collider != null;

        if (projectileHit.collider != null || projectileHitLeft.collider != null || projectileHitRight.collider !=null)
        {
            Debug.DrawLine(position, projectileHit.point, Color.red);
        }
    }
}
