using UnityEngine;
using System.Collections.Generic;

public class NPCQuest : NPC {
	
	AdminQuest aq;
	List<Quests> quests = new List<Quests> ();
	int missionPos;
	int missionId;
	public Texture2D questNameBackground;
	int dialog;
	Vector3 pos;
	public Material noQ;
	public Material yesQ;
	
	int questShow;

	public List<QuestsList> questList;
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		aq = GameObject.FindGameObjectWithTag ("QuestObject").GetComponent<AdminQuest>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mustShow)
			GameObject.FindGameObjectWithTag ("Player").transform.position = pos;
	}

	public void lookForQ(){
		for (int i = 0; i < questList.Count; i++) {
			if (aq.getStatus (questList [i].id) != questStatus.Finished) {
				quests.Add (aq.giveQuest (questList [i].id));
			}
		}
		if (quests.Count > 0) {
			transform.FindChild ("Plane").renderer.material = yesQ;
		} else {
			transform.FindChild ("Plane").renderer.material = noQ;
		}
	}

	protected override void OnMouseDown(){
		base.OnMouseDown ();
		quests.Clear ();
		for (int i = 0; i < questList.Count; i++) {
			if (aq.getStatus (questList [i].id) != questStatus.Finished) {
				mustShow = true;
				pos = GameObject.FindGameObjectWithTag("Player").transform.position;
				typeMessage = typeTalk.AllQuests;
				quests.Add (aq.giveQuest (questList [i].id));
			}
		}
		if (quests.Count == 0) {
			mustShow = true;
			pos = GameObject.FindGameObjectWithTag("Player").transform.position;
			typeMessage = typeTalk.Default;
			message = defaultText;
		}
	}

	protected override void OnGUI(){
		if (mustShow) {
			GUI.skin = skin;
			GUI.DrawTexture (rBack, talkBackground, ScaleMode.StretchToFill);
				if (typeMessage == typeTalk.AllQuests) {
					GUI.BeginGroup (rText);
					questShow = Mathf.Abs (questShow) % quests.Count;
					GUI.DrawTexture (new Rect (0, 0, 200, 40), questNameBackground);
					if (GUI.Button (new Rect (0, 0, 200f, 40), quests [questShow].name)) {
						for (int j = 0; j < questList.Count; j++) {
							if (quests [questShow].id == questList [j].id) {
								missionPos = j;
								missionId = quests [questShow].id;
								dialog = 0;
								typeMessage = typeTalk.Quest;
							}
						}
					}
					if (quests.Count > 1) {
						if (questShow == 0) {
							if (GUI.Button (new Rect (150, 25, 150f, 25), nextQ)) {
								questShow++;
							}
						} else {
							if (questShow == quests.Count - 1) {
								if (GUI.Button (new Rect (150, 0, 150f, 25), backQ)) {
									questShow--;
								}
							} else {
								if (GUI.Button (new Rect (150, 0, 150f, 25), backQ)) {
									questShow--;
								}
								if (GUI.Button (new Rect (150, 25, 150f, 25), nextQ)) {
									questShow++;
								}
							}
						}
					}
					GUI.EndGroup ();
					if (GUI.Button (rDecline, cancelButton)) {
						mustShow = false;
					}
				}
				if (typeMessage == typeTalk.Default) {
					GUI.Label (rText, message);
					if (GUI.Button (rAccept, acceptButton))
						mustShow = false;
				}
				if (typeMessage == typeTalk.Quest) {
					questStatus status = aq.getStatus (missionId);
					if (status == questStatus.Free) {
						GUI.Label (rText, questList [missionPos].DialogQuestSetup [dialog].messages);
						if (dialog + 1 == questList [missionPos].DialogQuestSetup.Count) {
							if (GUI.Button (rAccept, acceptButton)) {
								aq.activeQuest (missionId);
								mustShow = false;
							}
							if (GUI.Button (rDecline, cancelButton)) {
								mustShow = false;
							}
						} else {
							if (GUI.Button (rAccept, acceptButton)) {
								dialog++;
							}
						}
					} else if (status == questStatus.InProgress) {
						GUI.Label (rText, questList [missionPos].DialogQuestInProgress [dialog].messages);
						if (GUI.Button (rAccept, acceptButton)) {
							mustShow = false;
						} 
					} else if (status == questStatus.Completed) {
						GUI.Label (rText, questList [missionPos].DialogQuestComplet [dialog].messages);
						if (GUI.Button (rAccept, acceptButton)) {
							mustShow = false;
							aq.finishQuest (missionId);
							stp.addEXP (aq.giveQuest (missionId).expReward);
							stp.addMoney (aq.giveQuest (missionId).moneyReward);
						}
					}
				}
		}
	}
}
