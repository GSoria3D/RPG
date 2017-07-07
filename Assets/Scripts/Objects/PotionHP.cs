using UnityEngine;
using System.Collections;

public class PotionHP : Objects {

	public int hpIncress;
	
	public override void execute(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Stats>().addHP(hpIncress);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PJHaversack> ().subObject (id);
	}
}
