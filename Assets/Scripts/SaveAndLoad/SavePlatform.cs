using UnityEngine;
using System.Collections;

public class SavePlatform : MonoBehaviour {

	bool mustShow = false;
	public Texture2D box;
	public Texture2D accept;
	public Texture2D cancel;
	public GUISkin skin;
	Vector3 pos;
	void Update(){
		if (mustShow)
			GameObject.FindGameObjectWithTag ("Player").transform.position = pos;
	}
	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			mustShow = true;
			pos = GameObject.FindGameObjectWithTag("Player").transform.position;
		}
	}

	void OnGUI(){
		if (mustShow) {
			GUI.skin = skin;
			GUI.DrawTexture(new Rect (Screen.width / 2 -150, Screen.height / 2 -150, 300, 300), box,ScaleMode.StretchToFill);
			if (GUI.Button (new Rect (Screen.width / 2 -150 + 75, Screen.height / 2 -150 +85, 150, 50), accept)){
				SaveLoad.Save ();
				mustShow = false;
			}
			if (GUI.Button (new Rect (Screen.width / 2 -150 + 75, Screen.height / 2 -150 +165, 150, 50), cancel))
				mustShow = false;
		}
	}
}
