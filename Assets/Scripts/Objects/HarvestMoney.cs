using UnityEngine;
using System.Collections;

public class HarvestMoney : MonoBehaviour {

	public int moneyValue = 5;
	public float timeDissapear = 15;
	float time;
	// Use this for initialization
	void Start () {
		time = Time.time + 15;
	}
	
	// Update is called once per frame
	void Update () {
		if (time < Time.time)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().addMoney(moneyValue);
			Destroy(this.gameObject);
		}
	}
}
