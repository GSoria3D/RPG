using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {

	public GameObject ice;
	float time;
	float secondToShoot = 10;
	GameObject player;
	public Vector3 positionPlayer;

	// Use this for initialization
	void Start () {
		if (!GameObject.FindGameObjectWithTag ("QuestObject").GetComponent<AdminQuest> ().quests [GameObject.FindGameObjectWithTag ("QuestObject").GetComponent<AdminQuest> ().quests.Count - 1].process)
			this.gameObject.SetActive (false);
		time = Time.time;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (time < Time.time) {
				Instantiate(ice);
			time = Time.time + secondToShoot;
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Attack"){
			player.transform.position = positionPlayer;
			secondToShoot = secondToShoot * 0.9f;
			Destroy(c);
        }
	}
}
