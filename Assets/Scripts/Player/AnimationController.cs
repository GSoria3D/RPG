using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
	
	Animator anim;
	bool attacking = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		attacking = Input.GetMouseButtonUp (1);

		float speed = Input.GetAxis ("Horizontal") + Input.GetAxis ("Vertical");
		anim.SetBool ("Attacking", attacking);
		anim.SetFloat ("Speed", speed);
	}

	public void Died(){
		anim.SetTrigger ("Dead");
	}
}