using UnityEngine;
using System.Collections;

public class InitialMenuScript : MonoBehaviour {

	public Texture2D start;
	public Texture2D load;
	static public bool loaded = false;
	public GUISkin skin;

	void OnGUI(){
		if (!loaded) {
			GUI.skin = skin;
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 200, 100), start)) {
				GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGameUIMagicalPowers> ().enabled = true;
				GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGameUIStats> ().enabled = true;
				GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGamePauseScript> ().enabled = true;
				this.enabled = false;
				this.camera.enabled = false;
				loaded = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2 + 150, 200, 100), load)) {
				SaveLoad.Load ();
				loaded = true;
			}
		} else {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGameUIMagicalPowers> ().enabled = true;
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGameUIStats> ().enabled = true;
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<InGamePauseScript> ().enabled = true;
			this.enabled = false;
			this.camera.enabled = false;
			loaded = true;
		}
		GameObject.FindGameObjectWithTag("QuestObject").GetComponent<AdminQuest>().callToNPC();
	}
}
