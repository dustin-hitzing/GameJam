using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
	public float projectileSpeed = 2000f;
	public int shotsAvailable = 15;
	// public LayerMask collisionLayers;
	public GameObject projectile;
	List<GameObject> projectiles = new List<GameObject>();
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

	void ThrowProjectile()
	{
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		GameObject shotFired = (GameObject) Instantiate(projectile, firePointPosition, firePoint.transform.rotation);
		
		Vector2 direction = firePoint.transform.right;
		if (transform.parent.localScale.x < 0)
        {
			direction = -firePoint.transform.right;
			shotFired.transform.localScale = new Vector2(shotFired.transform.localScale.x * -1, shotFired.transform.localScale.y);
		}

		shotFired.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);

		projectiles.Add(shotFired);
		shotsAvailable--;
	}

	void RecallProjectile()
	{
		GameObject last = projectiles.Last();
		projectiles.RemoveAt(projectiles.Count - 1);
		Destroy(last);
		shotsAvailable++;
	}
}
