using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{


	public GameObject player;
	public float attackRange;
	public Transform firePoint;
	public GameObject projectile;
	public float fireRate;
	private float nextFire;
	public bool doesnotDisengage = false; // Finds player, doesn't stop attacking.
	private bool playerFound = false;

	//private float damping = 6.0f;
	public float movementSpeed = 1.0f;

	// Use this for initialization
	void Start ()
	{
		playerFound = false;

		if (GetComponent<Rigidbody> ()) {
			GetComponent<Rigidbody> ().freezeRotation = true;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (player) {
			if (attackRange > Vector3.Distance (player.transform.position, transform.position)
				|| playerFound) {
				// We found the Player 7 We don't want to stop attacking
				if (doesnotDisengage) {
					playerFound = true;
				}
				// Look AT Player
				transform.LookAt (player.transform);


				// Movement
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, movementSpeed);


				if (Time.time > nextFire) {
					nextFire = Time.time + fireRate;

					GameObject bullet = Instantiate (projectile, firePoint.position, firePoint.rotation) as GameObject;
				
					bullet.GetComponent<Projectile> () .CreatedBy ("Enemy");
				}

			} else {
			}
		} else {
			player = GameObject.FindGameObjectWithTag ("Player");
			
		}
	}

	public Transform[] wayPoints;
	public int currentWP;
	public float distanceToWayPoint = 1.0f;

	private void Patrol ()
	{
		if (wayPoints.Length == 0) {

			return;
		}
		if (wayPoints [currentWP] == null) {

			nextWayPoint ();
			return;
		}
		
		
		if (distanceToWayPoint > Vector3.Distance (wayPoints [currentWP].position, transform.position)) {
			{
				nextWayPoint ();
			}
		} else {
			transform.LookAt (wayPoints [currentWP]);
		}

	}

	private void nextWayPoint ()
	{

		currentWP++;
		if (currentWP > wayPoints.Length - 1) {
			currentWP = 0;
		}
	} 
}


