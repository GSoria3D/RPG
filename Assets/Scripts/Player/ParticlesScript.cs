using UnityEngine;
using System.Collections;

public class ParticlesScript : MonoBehaviour {

	int damage;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<ParticleSystem>().isPlaying)
			Destroy (this.gameObject);
	}
	
	public void setDamage(int _damage){
		damage = _damage;
	}
	
	void OnParticleCollision(GameObject other){
		if (other.tag == "enemy") {
			other.GetComponent<EnemyStats>().subHP(damage);
		}
	}
}
