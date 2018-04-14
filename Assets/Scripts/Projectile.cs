using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour {
	public float speed = 500f;
	private Rigidbody2D rb;
	// private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce(transform.up * speed);
		// boxCollider = GetComponent<BoxCollider2D> ();
	}
}
