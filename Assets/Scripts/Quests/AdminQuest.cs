using UnityEngine;
using System.Collections.Generic;

public class AdminQuest : MonoBehaviour {
	
	public List<Quests> quests;
	public static AdminQuest aq;
	// Use this for initialization
	PJHaversack p;
	Stats s;
	public static List<Quests> q;

	void Awake(){
		if (aq == null) {
			aq = this;
			DontDestroyOnLoad (gameObject);
		} else if (aq != this)
			Destroy (gameObject);
	}
	void Start () {
		q = quests;
		p = GameObject.FindGameObjectWithTag ("Player").GetComponent<PJHaversack> ();
		s = GameObject.FindGameObjectWithTag ("Player").GetComponent<Stats> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool canAccept(int id){
		
		foreach (Quests q in quests)
		if (q.id == id) {
			return !q.process && !q.finished;
		}
		return false;
	}

	
	public Quests giveQuest(int id){
		foreach (Quests q in quests)
		if (q.id == id) {
			return q;
		}
		return null;
	}

	public void activeQuest(int id){
		foreach (Quests q in quests)
			if (q.id == id) {
				q.process = true;
				break;
			}
	}

	public void finishQuest(int id){
		foreach (Quests q in quests)
		if (q.id == id) {
			q.finished = true;
			callToNPC();
			break;
		}
	}

	public void callToNPC(){
		GameObject[] npcs;
		npcs = GameObject.FindGameObjectsWithTag ("NPC");
		foreach (GameObject npc in npcs) {
			if(npc.GetComponent<NPCQuest>() != null)
				npc.GetComponent<NPCQuest>().lookForQ();
		}
	}

	public questStatus getStatus(int id){
		foreach (Quests q in quests){
			if (q.id == id) {
				if (q.finished)
					return questStatus.Finished;
				if (q.process) {
					bool completed = true;
					for (int i = 0; i <q.monsterkill.Count && completed; i++) {
						if (q.monsterkill [i].amount > q.monsterkill [i].rest)
							completed = false;
					}
					for (int i = 0; i <q.objectgiven.Count && completed; i++) {
						if (!p.haveObject (q.objectgiven [i].id, 1))
							completed = false;
					}
					for (int i = 0; i <q.objectcollect.Count && completed; i++) {
						if (!p.haveObject (q.objectcollect [i].id, q.objectcollect [i].amount))
							completed = false;
					}
					if (completed)
						return questStatus.Completed;

					return questStatus.InProgress;
				}

				if (q.neccesaryLevel <= s.a.level) {
					if (q.previouslyQuestId != -1) {
						foreach (Quests q2 in quests) {
							if (q.previouslyQuestId == q2.id) {
								if (q2.finished)
									return questStatus.Free;
								else
									return questStatus.Finished;
							}
						}
					}
					return questStatus.Free;
				} else
					return questStatus.Finished;
			}
		}
		return questStatus.Free;
	}

	public void monsterKilled(int id){
		foreach (Quests q in quests) {
			if(q.process)
				for (int i = 0; i <q.monsterkill.Count; i++) {
					if (q.monsterkill [i].id == id)
						q.monsterkill [i].rest++;
			}
		}
	}
}
