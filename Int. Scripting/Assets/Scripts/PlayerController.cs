using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float moveForce = 365f; // amount of force that will move the player

	public float maxSpeed = 5f; // the max speed of the player

	private Transform thisTransform; // cache of the this.transform
	private Rigidbody2D thisRigidbody; // cache of the this.rigidbody

	private float h; // horizontal input temp 
	private float v; // vertical input 

	// Use this for initialization
	void Start () {
		thisTransform = this.transform;
		thisRigidbody = this.rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// independent of the frame rate
	void FixedUpdate() {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		if (Mathf.Abs(h * thisRigidbody.velocity.x) < maxSpeed) {
			thisRigidbody.AddForce( Vector2.right * h * moveForce );
		}

		if (Mathf.Abs(v * thisRigidbody.velocity.y) < maxSpeed) {
			thisRigidbody.AddForce( Vector2.up * v * moveForce );
		}
	}
}











