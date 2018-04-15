using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
	// float anchorDepth = 2f;
	public LayerMask canHit;
	Rigidbody2D rb;
	bool hit = false;
    public GameObject enemy;
    public EnemyAI enemyAI;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
        enemyAI = enemy.GetComponent<EnemyAI>();
		//Physics2D.SetLayerCollisionMask(gameObject.layer, canHit);
	}

 	void OnCollisionEnter2D(Collision2D other)
	{
        //Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer != 8 && other.gameObject.layer != 11)
        {
            return;
        }
        //Debug.Log(string.Format("hit {0} and layer is {1}", !hit, other.gameObject.layer));
        if (!hit && other.gameObject.layer == 8)
		{
        	StickToSurface(other);
            hit = true; 
        }
        //Debug.Log(string.Format("hit {0} and layer is {1}", !hit, other.gameObject.layer));
        if (!hit && other.gameObject.layer == 11)
        {
            enemyAI.KOEnemy();
            //Debug.Log(enemy.currentState);

            //Debug.Log("I am KO'd");
            StickToSurface(other);
            transform.parent = other.transform;

            hit = true;  
        }
    }

 	void StickToSurface(Collision2D col)
 	{
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
        //Debug.Log("I was called");
		// Sink into the wall a bit.
		// transform.Translate(anchorDepth * -Vector2.right);
 	}
}
