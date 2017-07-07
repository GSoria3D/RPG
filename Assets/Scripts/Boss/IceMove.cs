using UnityEngine;
using System.Collections;

public class IceMove : MonoBehaviour {

	float speed = 0.008f;
	GameObject player;
	Vector3 position;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		position = player.transform.position;
		position -= transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (position * speed);
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			player.GetComponent<Stats> ().subHP (50);
			Destroy(this.gameObject);
		}
	}
}
