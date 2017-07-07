using UnityEngine;
using System.Collections;

public class MagicalAttack : MonoBehaviour {

	Attacks.Attack selectedAttack;

	// Use this for initialization
	void Start () {
		selectedAttack = GetComponent<Attacks> ().attacks [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (1) && GetComponent<Stats>().a.sp > selectedAttack.sp) {
			GameObject a;
			Vector3 pos = transform.position;
			pos.y += 3;
			a = (GameObject) Instantiate(selectedAttack.p,pos,transform.rotation);
			a.GetComponent<Ball>().execute();
			a.GetComponent<Ball>().setDamage(selectedAttack.damage * gameObject.GetComponent<Stats>().a.level);
			GetComponent<Stats>().subSP(selectedAttack.sp);
		}
	}

	public void setAttack(Attacks.Attack attack){
		selectedAttack = attack;
	}


}
