using UnityEngine;
using System.Collections;

public class PJSingleton : MonoBehaviour {

	
	public static PJSingleton s;
	// Use this for initialization
	void Awake(){
		if (s == null) {
			s = this;
			DontDestroyOnLoad (gameObject);
		} else if (s != this)
			Destroy (gameObject);
	}
}
