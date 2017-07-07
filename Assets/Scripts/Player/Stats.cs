using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	[System.Serializable]
	public class Attribute
	{
		public int hpMax = 1000,spMax = 100;
		public int hp = 900,sp = 100,exp = 0,necessaryExp,money;
		public int level = 1;
	}

	public static Attribute current;
	AnimationController ac;
	public Attribute a;

	void Start () {
		current = a;
		ac = GetComponent<AnimationController> ();
		a.necessaryExp =(int)( 5/4 * Mathf.Pow (a.level, 3));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addHP(int _hp){
		a.hp += _hp;
		if (a.hp > a.hpMax)
			a.hp = a.hpMax;
	}

	public void addSP(int _sp){
		a.sp += _sp;
		if (a.sp > a.spMax)
			a.sp = a.spMax;
	}

	public void addEXP(int _exp){
		a.exp += _exp;
		revisaNivel ();
	}

	public void addMoney(int _money){
		a.money += _money;
	}

	public void subHP(int _hp){
		a.hp -= _hp;
		if (a.hp <= 0) {
			ac.Died();
			InitialMenuScript.loaded = true;
			a.hp = a.hpMax;
			subExp((int)(a.necessaryExp * 0.1));
			
			GameObject.FindGameObjectWithTag("Player").GetComponent<Maps>().lastMap = "Dessert";
			GameObject.FindGameObjectWithTag("Player").GetComponent<Maps>().actualMap = "Town";
			Application.LoadLevel("Town");
		}
	}

	public void subExp(int _exp){
		a.exp -= _exp;
		if (a.exp < 0)
			a.exp = 0;
	}
	
	public void subSP(int _sp){
		a.sp -= _sp;
		if (a.sp < 0)
			a.sp = 0;
	}

	
	public bool subMoney(int _money){
		if (_money > a.money)
			return false;
		a.money -= _money;
		return true;
	}

	void revisaNivel(){
		if (a.exp > a.necessaryExp) {
			a.level += 1;
			a.exp = a.exp - a.necessaryExp;
			a.necessaryExp =(int)( 5/4 * Mathf.Pow (a.level, 3));
		}
	}

	public float getPercentHP()
	{
		return (a.hp * 100 / a.hpMax) ;
	}

	public float getPercentSP(){
		return (a.sp * 100 / a.spMax) ;
	}
}
