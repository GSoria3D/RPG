using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Vector3 initialPosition;

	Collider[] vision, attack, maxDistance;

	float visionRatio = 30, attackRatio = 5, maxDistanceRatio = 50;

	NavMeshAgent agent;

	Vector3 destination;
	bool isOutBounds = false;

	GameObject player;

	Animator anim;

	float nextAttack = 0;
	float timeBetweenAttack = 10;
	bool isAttacking = false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		isOutBounds = true;
		maxDistance = Physics.OverlapSphere (initialPosition, maxDistanceRatio);
		foreach (Collider c in maxDistance) {
			if (c.gameObject == gameObject) {
				isOutBounds = false;
			}
		}

		if (isOutBounds) {
			agent.SetDestination (initialPosition);
		} else {
			isAttacking = false;
			if (nextAttack == 0 || nextAttack < Time.time) {
				attack = Physics.OverlapSphere (transform.position, attackRatio);
				foreach (Collider c in attack) {
					if (c.gameObject.tag == "Player") {
						player.GetComponent<Stats> ().subHP (GetComponent<EnemyStats> ().attackDamage);
						nextAttack = timeBetweenAttack + Time.time;
						isAttacking = true;
					}
				}
			}

			if(!isAttacking){
				vision = Physics.OverlapSphere (transform.position, visionRatio);
				foreach (Collider c in vision) {
					if (c.gameObject.tag == "Player") {
						agent.SetDestination (c.gameObject.transform.position);
					}
				}
			}
		}
		anim.SetBool ("Attacking", isAttacking);
		anim.SetBool ("Moving", agent.hasPath);
	}
}
