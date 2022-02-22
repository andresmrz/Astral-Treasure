using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;	// Detection range for player

	public GameObject Player;	// Reference to the player
	public NavMeshAgent _agent; // Reference to the NavMeshAgent


	// Use this for initialization
	void Start () {
		//agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		// Distance to the target
		float distance = Vector3.Distance(Player.transform.position, transform.position);

		// If inside the lookRadius
		if (distance <= lookRadius)
		{
			// Move towards the target
			_agent.SetDestination(Player.transform.position);

		}

	}
	
	// Show the lookRadius in editor
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
