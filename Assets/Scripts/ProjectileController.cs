using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
	public List<GameObject> projectiles = new List<GameObject>();
	public int shotsAvailable = 15;
	// public LayerMask collisionLayers;
	public GameObject projectile;
	Transform firePoint;

	// public Vector2 offset = new Vector2(0.4f,0.1f);
	// public float cooldown = 1f;

	// Use this for insitilization.
	void Awake() 
	{
		firePoint = transform.Find("FirePoint");
		if (firePoint == null) 
		{
			Debug.LogError("No fire point.");
		}
	}

	// Update is called once per frame
	void Update ()
	{	
		if (Input.GetButtonDown("Fire1") && shotsAvailable > 0) 
		{
			ThrowProjectile();
		}

		if (Input.GetButtonDown("Fire2") && projectiles.Count > 0) 
		{
			RecallProjectile();
		}
	}

	void ThrowProjectile() {
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		Instantiate(projectile, firePointPosition, firePoint.transform.rotation);

		projectiles.Add(projectile);
		shotsAvailable--;
	}

	void RecallProjectile() {
		//To Do.
		Debug.Log("Recalling projectile");
	}
}
