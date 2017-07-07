using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	int damage;
	Vector3 initialPos;
	public GameObject destroy;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * 15f * Time.deltaTime);
		if (Vector3.Distance (initialPos, transform.position) > 15)
			Destroy (this.gameObject);
	}
	public void setDamage(int _damage){
		damage = _damage;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "enemy") {
			other.GetComponent<EnemyStats>().subHP(damage);
			Destroy(this.gameObject);
		}
	}

	void OnDestroy(){
		Instantiate(destroy,transform.position,new Quaternion());
	}

	public void execute(){}
}
