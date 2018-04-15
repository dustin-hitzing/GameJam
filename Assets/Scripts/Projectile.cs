using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour {
	// float anchorDepth = 2f;
	public LayerMask canHit;
	Rigidbody2D rb;
	bool hit = false;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		Physics2D.SetLayerCollisionMask(gameObject.layer, canHit);
	}

 	void OnCollisionEnter2D(Collision2D other)
	{
        if (!hit)
		{
        	StickToSurface(other);
            hit = true; 
        }
    }

 	void StickToSurface(Collision2D col)
 	{
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
		
		// Sink into the wall a bit.
		// transform.Translate(anchorDepth * -Vector2.right);
 	}
}
