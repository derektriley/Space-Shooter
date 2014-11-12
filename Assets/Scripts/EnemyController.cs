using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public Boundary boundary;

	public float fireRate;
	public float nextFire;

	void Update() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
		}
	}

	void FixedUpdate() {
		Vector3 movement = new Vector3 (0.0f, 0.0f, -1.0f);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3 
			(	 
			 Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			 0.0f,
			 rigidbody.position.z
			 );
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 180.0f, rigidbody.velocity.x * -tilt);
	}

}
