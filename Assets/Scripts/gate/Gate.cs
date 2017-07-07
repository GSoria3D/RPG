using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	public string goTo;
	Stats stats;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Maps>().lastMap = Application.loadedLevelName;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Maps>().actualMap = goTo;
			Application.LoadLevel(goTo);
		}
	}
}
