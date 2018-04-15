using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameJam.States;

public class BroadcastToEnemy : MonoBehaviour
{
    public List<EnemyAI> enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponentInParent<EnemyAI>();
        enemy.currentState = EnemyState.Chasing;
        Debug.Log("I've Been Called");
    }

    private void Update()
    {
       
    }
}
