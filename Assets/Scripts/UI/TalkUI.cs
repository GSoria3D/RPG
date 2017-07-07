using UnityEngine;
using System.Collections;

public class TalkUI : MonoBehaviour {

	public enum typeTalk{Default,Quest,Dialog};

	string message;
	typeTalk type;
	bool mustShow;
	int idQ;
	Rect rText = new Rect(100,Screen.height * 0.8f,Screen.width - 100,Screen.height*0.7f);
	Rect rAccept = new Rect(Screen.width/2 - 50f,Screen.height * 0.8f,100f,Screen.height*0.2f/2);
	Rect rDecline = new Rect(Screen.width/2 +100f,Screen.height * 0.8f,100f,Screen.height*0.2f/2);
	Rect rOk = new Rect(Screen.width/2 - 50f,Screen.height * 0.8f,100f,Screen.height*0.2f/2);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void enterMessage(string _m, typeTalk _t){
		message = _m;
		type = _t;
		mustShow = true;
	}

	public void enterMessage(string _m, typeTalk _t,int idQuest){
		message = _m;
		type = _t;
		idQ = idQuest;
		mustShow = true;
	}

	void OnGUI(){
		if (mustShow) {
			GUI.Box(rText,"");
			GUI.Label (rText, message);
			if(type == typeTalk.Default){
				if(GUI.Button(rOk,"Continue"))
					mustShow = false;
			}
			if(type == typeTalk.Dialog){
				if(GUI.Button(rOk,"Continue")){
					mustShow = false;
				}
			}
			if(type == typeTalk.Quest){
				if(GUI.Button(rAccept,"Accept")){
					GameObject.FindGameObjectWithTag("QuestObject").GetComponent<AdminQuest>().activeQuest(idQ);
					mustShow = false;
				}
				if(GUI.Button(rDecline,"Decline")){
					mustShow = false;
				}
			}
				
		}
	}
}
