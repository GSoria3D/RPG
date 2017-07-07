using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public int hpMax = 100,spMax = 100;
	public int hp = 100,sp = 100,exp = 0;
	bool died = false;
	public int attackDamage = 10;
	public int id;
	public string monsterName;
	public GameObject money;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public float probability1;
	public float probability2;
	public float probability3;
	Animator anim;
	AdminQuest aq;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		aq = GameObject.FindGameObjectWithTag ("QuestObject").GetComponent<AdminQuest>();
	}
	
	// Update is called once per frame
	void Update () {
		if (died) {
			Destroy (this.gameObject);
			GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().addEXP(exp);
			aq.monsterKilled(id);
			spawn();
		}
	}
	
	public void addHP(int _hp){
		hp += _hp;
		if (hp > hpMax)
			hp = hpMax;
	}
	
	public void addSP(int _sp){
		sp += _sp;
		if (sp > spMax)
			sp = spMax;
	}
	
	public void addEXP(int _exp){
		exp += _exp;
	}
	
	public virtual void subHP(int _hp){
		hp -= _hp;
		if (hp <= 0) {
			anim.SetTrigger("Died");
			died = true;
		}
	}
	
	public void subSP(int _sp){
		sp -= _sp;
		if (sp < 0) {
			sp = 0;
		}
	}

	void spawn(){
		for(int i = 0; i < Random.Range(1,3); i++){
			Vector3 v = new Vector3(transform.position.x + Random.Range(0,10),transform.position.y + 0.5f, transform.position.z + Random.Range(0,10));
			Instantiate(money, v, new Quaternion());
		}
		if(spawn1 != null && Random.Range(0f,1f) > probability1){
			Vector3 v = new Vector3(transform.position.x + Random.Range(0,10),transform.position.y + 0.5f, transform.position.z + Random.Range(0,10));
			Instantiate(spawn1, v, new Quaternion());
		}
		if(spawn2 != null && Random.Range(0f,1f) > probability2){
			Vector3 v = new Vector3(transform.position.x + Random.Range(0,10),transform.position.y + 0.5f, transform.position.z + Random.Range(0,10));
			Instantiate(spawn2, v, new Quaternion());
		}
		if(spawn3 != null && Random.Range(0f,1f) > probability3){
			Vector3 v = new Vector3(transform.position.x + Random.Range(0,10),transform.position.y + 0.5f, transform.position.z + Random.Range(0,10));
			Instantiate(spawn3, v, new Quaternion());
		}
	}
}
