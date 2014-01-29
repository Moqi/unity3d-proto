using UnityEngine;
using System.Collections;

public class MoveEnemyToTarget : MonoBehaviour {
	
	GameObject player;	 
	float speed=(float)5.0;
	
	private Vector3 desiredVelocity ;
	private float lastSqrMag;
	
	bool isReachedObj=false;
	
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player");
		
		// calculate directional vector to target
		Vector3 directionalVector  = (player.transform.position - transform.position).normalized * speed;
		// reset lastSqrMag (Distance between target and enemy)
		lastSqrMag = Mathf.Infinity;
		//		print("AttachPlayer Start "+lastSqrMag);
		// set required velocity 
		desiredVelocity = directionalVector;
	}
	
	// Update is called once per frame
	void Update () {
		// check the current sqare magnitude
		if(isReachedObj)
			return ;
		
		float sqrMag  = (float)(player.transform.position - transform.position).sqrMagnitude;
		// check this against the lastSqrMag
		// if this is greater than the last,
		// rigidbody has reached target and is now moving past it
		if ( sqrMag > lastSqrMag )
		{
			isReachedObj=true;
			animation.Play("idle");
			print("Rigid body has reached the player");
			// rigidbody has reached target and is now moving past it
			// stop the rigidbody by setting the velocity to zero
			desiredVelocity = Vector3.zero;
			// apply velocity to enemy
			rigidbody.velocity = desiredVelocity;
		}else{
			// apply velocity to enemy
			rigidbody.velocity = desiredVelocity;
			// make sure you update the lastSqrMag
			lastSqrMag = sqrMag;
			animation.Play("back");
		} 
	}
}
