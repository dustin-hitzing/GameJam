using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.States;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public CircleCollider2D sight;
    public GameObject target;
    public BoxCollider2D targetCollider;
    public float enemySpeed = 2f;
    public Vector3 offset = new Vector3(5,0,0);
    public Vector2 smoothedPosition;
    public EnemyState currentState;
    public LayerMask playerLayer;
    public Animator anim;
    public SpriteRenderer sr;
    

    public List<Collider2D> projectiles;
	
	void Start ()
    {
        currentState = EnemyState.Idle;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
        Debug.Log(currentState);
        SeePlayer();
        Debug.Log(currentState);
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
    public void KOEnemy()
    {
        currentState = EnemyState.KO;
        Debug.Log(anim);
        if (anim != null && !anim.GetBool("isPunctured"))
        {
            anim.SetBool("isPunctured", true);
            Debug.Log(string.Format("HEY THIS THING IS WORKING INSIDE THE IF STATEMENT {0}", anim));
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 9)
        {
            KOEnemy();
            projectiles.Add(other.collider);
        }
        if (other.gameObject.layer == 10)
        {
            SceneManager.LoadScene("Main");
               
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == 9)
        {
            KOEnemy();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        projectiles.Remove(other.collider);
        if (projectiles.Count == 0)
        {
            if (anim != null)
            {
                anim.SetBool("isPunctured", false);
            }
            enemySpeed += 2f;
            if (enemySpeed > 20f)
            {
                enemySpeed = 20f;
            }
            
            currentState = EnemyState.Idle;
            
        }
        
       
    }
    void SeePlayer()
    {
        Vector2 positon = transform.position;
        Vector2 topPosition = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 bottomPosition = new Vector2(transform.position.x, transform.position.y - 1);
        Vector2 right = Vector2.right;
        Vector2 left = Vector2.left;
        if (currentState == EnemyState.KO)
        {
            return;
        }

        RaycastHit2D sightRight = Physics2D.BoxCast(transform.position, new Vector2(15, 15), 0f, Vector2.right, playerLayer);
        if (sightRight.collider != null)
        {
            currentState = EnemyState.Chasing;
            //Debug.Log("Box Cast Entered");
        }
        
    }

    void EnemyIsChasing()
   {
        smoothedPosition = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        if (target.transform.position.x > transform.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;

        }
        //Debug.Log("I Was Called");
   }
    
}
