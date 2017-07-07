using UnityEngine;
using System.Collections;

public class InGameUIMagicalPowers : MonoBehaviour {

	public GUISkin skin;
	GameObject player;
	Attacks attacks;
	int selectedAttack = 0;

	
	float leftGroup = Screen.width * .7f;
	float topGroup = Screen.height * .8f;
	float widthGroup = Screen.width * .3f;
	float heightGroup = Screen.height * .2f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		attacks = player.GetComponent<Attacks> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (attacks.attacks [Mathf.Abs (selectedAttack + (int)Input.mouseScrollDelta.y) % attacks.attacks.Length].necessaryLevel <= player.GetComponent<Stats> ().a.level) {
			selectedAttack += (int)Input.mouseScrollDelta.y;
			if (Input.mouseScrollDelta.y != 0) {
				player.GetComponent<MagicalAttack> ().setAttack (attacks.attacks [Mathf.Abs (selectedAttack) % attacks.attacks.Length]);
			}
		}
	}

	void OnGUI(){
		GUI.skin = skin;
		int acum = 0;
		GUI.BeginGroup (new Rect (leftGroup,topGroup,widthGroup,heightGroup));
			GUI.Label (new Rect (widthGroup * .05f,heightGroup * 0.5f,100,30), "Magical Power");
		for (int i = selectedAttack; i < attacks.attacks.Length + selectedAttack; i++) {
			if(attacks.attacks[Mathf.Abs(i) % attacks.attacks.Length].necessaryLevel <= player.GetComponent<Stats>().a.level){
				GUI.Label (new Rect (widthGroup * .05f + 100,heightGroup * 0.5f - 32 + 64*acum,64,64), attacks.attacks[Mathf.Abs(i) % attacks.attacks.Length].texture);
				acum++;
			}
		}
			
		GUI.EndGroup ();
	}
}
