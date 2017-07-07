using UnityEngine;
using System.Collections.Generic;

public class NPC : MonoBehaviour {
	public enum typePJConversation{NPCTalk,PlayerTalk,Other};
	public enum typeTalk{Default,Quest,AllQuests};
	[System.Serializable]
	public class QuestsList{
		
		public int id;
		public List<QuestsMessage> DialogQuestSetup;
		public List<QuestsMessage> DialogQuestInProgress;
		public List<QuestsMessage> DialogQuestComplet;
		
	}

	[System.Serializable]
	public class QuestsMessage{

		public typePJConversation theName; //Se puede cambiar por fotos
		public string messages;
		
	}

	public string NPCName;
	public int id;
	public string defaultText;
	protected Stats stp;

	
	protected Rect rBack = new Rect(0,Screen.height * 0.8f,Screen.width,Screen.height*0.2f);
	protected Rect rText = new Rect(100,Screen.height * 0.8f+40,Screen.width,Screen.height*0.2f);
	protected Rect rAccept = new Rect(Screen.width - 125f,Screen.height * 0.8f,100f,Screen.height*0.2f/2);
	protected Rect rDecline = new Rect(Screen.width - 125f,Screen.height * 0.8f+Screen.height*0.2f/2,100f,Screen.height*0.2f/2);
	protected Rect rOk = new Rect(Screen.width/2 - 50f,Screen.height * 0.8f,100f,Screen.height*0.2f/2);
	protected Rect rQuest = new Rect(Screen.width/2 - 50f,Screen.height * 0.8f,100f,20);
	protected bool mustShow;
	protected string message;
	protected typeTalk typeMessage;


	//UI
	public Texture2D talkBackground;
	public Texture2D acceptButton;
	public Texture2D cancelButton;
	public Texture2D nextQ;
	public Texture2D backQ;
	public GUISkin skin;

	// Use this for initialization
	protected virtual void Start () {
		stp = GameObject.FindGameObjectWithTag ("Player").GetComponent<Stats> ();
	}

	
	protected virtual void OnMouseDown(){

	}

	protected virtual void OnGUI(){
	}
}
