using UnityEngine;
using System.Collections;

public class Teleport : Ball {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Player").transform.Translate (Vector3.forward * 15);
	}
}
