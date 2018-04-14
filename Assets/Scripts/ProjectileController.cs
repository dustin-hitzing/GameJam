using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
	public List<GameObject> projectiles = new List<GameObject>();
	public int shotsAvailable = 15;
	// public LayerMask collisionLayers;
	public GameObject projectile;
	public Text counter;
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
		counter.text = shotsAvailable.ToString();
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
		

		projectiles.Add(shotFired);
		shotsAvailable--;
		counter.text = shotsAvailable.ToString();
	}

	void RecallProjectile()
	{
		GameObject last = projectiles.Last();
		projectiles.RemoveAt(projectiles.Count - 1);
		Destroy(last);
		shotsAvailable++;
		counter.text = shotsAvailable.ToString();
	}
}
