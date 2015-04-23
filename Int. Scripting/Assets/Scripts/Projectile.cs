using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage;
	public float fireRate;
	private string creator;
	public float speed;
	public float lifetime = 5.0f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.forward * speed;

		Destroy (this.gameObject, lifetime );
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D( Collider2D other) 
	{
		if (other.tag == "Player" && creator == "Enemy") {
			Debug.Log ("Hit Player");
		} 
		else if (other.tag == "Enemy" && creator == "Player"){
			Debug.Log ("Hit Enemy");

		}
	}

	public void CreatedBy (string tag) {
		creator = tag;
	}

	public float FireRate () {

		return fireRate;
	
	}
}
