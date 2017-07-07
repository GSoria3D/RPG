using UnityEngine;
using System.Collections;

public class InGamePauseScript : MonoBehaviour {
	bool mustShow;
	public Texture2D quit;
	public Texture2D load;
	public GUISkin skin;
	Vector3 pos;
	void Start(){
		mustShow = false;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			mustShow = !mustShow;
			if(mustShow){
				Time.timeScale = 0f;
			}else{
				Time.timeScale = 1f;
			}
		}
	}
	void OnGUI(){
		if (mustShow) {
			GUI.skin = skin;
			GUIStyle s = new GUIStyle();
			s.fontSize = 100;
			s.normal.textColor = Color.white;
			GUI.Label(new Rect(Screen.width / 2 - 150, 100,600,400),"PAUSE",s);
			if(GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 -75,300,150),load))
				SaveLoad.Load();
			if(GUI.Button(new Rect(Screen.width / 2  - 150, Screen.height / 2 + 50,300,150),quit))
				Application.Quit();
		}
	}
}
