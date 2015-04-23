using UnityEngine;
using System.Collections;

public class ExplodePlayer : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D( Collider2D other ) {

		if (other.CompareTag ("Player")) {
			Debug.Log ("EXPLOSION!!");

			Instantiate( explosion, 
			             other.transform.position, 
			             other.transform.rotation );

			Destroy( other.gameObject );
		}
	}
}










