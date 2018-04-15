using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.States;


public class EnemyAI : MonoBehaviour
{
    public CircleCollider2D sight;
    public GameObject target;
    public BoxCollider2D targetCollider;
    public float enemySpeed = 2f;
    public Vector3 offset = new Vector3(5,0,0);
    public Vector2 smoothedPosition;
    public EnemyState currentState;
	
	void Start ()
    {
        currentState = EnemyState.Idle;
	}

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 3000f);
        Debug.Log(collider.tag);
        if (collider.tag == "Player")
        {
            currentState = EnemyState.Chasing;
        }
        switch (currentState)
        {
            case EnemyState.Idle:
                {

                }
                break;
            case EnemyState.Chasing:
                {
                    EnemyIsChasing();
                }
                break;
            case EnemyState.KO:
                {

                }
                break;
            case EnemyState.Attacking:
                {

                }
                break;
        }
    }


    void EnemyIsChasing()
   {
        smoothedPosition = Vector2.MoveTowards(transform.position, target.transform.position - offset, enemySpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        Debug.Log("I Was Called");
   }
    
}
