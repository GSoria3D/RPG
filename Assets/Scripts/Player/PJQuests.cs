using UnityEngine;
using System.Collections.Generic;

public class PJQuests : MonoBehaviour {

	List<Quests> quests = new List<Quests>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addQuest(Quests q){
		quests.Add (q);
	}
}
