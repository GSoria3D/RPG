using UnityEngine;
using System.Collections;

public class PotionSP : Objects {

	public int spIncress;

	public override void execute(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Stats>().addSP(spIncress);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PJHaversack> ().subObject (id);
	}
}
