using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {

	public Transform target; // what to follow
	public float smoothTime = 0.3f; // smooth out the motion 

	private Transform thisTransform;
	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		thisTransform = this.transform;
	}
	
	void FixedUpdate() {
		if (target) {

			float x = Mathf.SmoothDamp( thisTransform.position.x,
			                            target.position.x,
			                            ref velocity.x,
			                            smoothTime );
			float y = Mathf.SmoothDamp( thisTransform.position.y,
			                            target.position.y,
			                            ref velocity.y,
			                            smoothTime );

			transform.position = new Vector3( x, y, thisTransform.position.z );
		}
	}
}
