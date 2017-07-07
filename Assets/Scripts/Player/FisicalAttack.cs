using UnityEngine;
using System.Collections;

public class FisicalAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.name);
		if (other.gameObject.tag == "enemy") {
			Debug.Log ("HOLA");
			other.gameObject.GetComponent<EnemyStats>().subHP(10);
		}
	}
}
