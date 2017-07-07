using UnityEngine;
using System.Collections;

public class Objects : MonoBehaviour {

		public int id;
		public string objectName;
		public int sellPrice;
		public int buyPrice;
		public string description;
		public Texture2D image;

	protected virtual void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<PJHaversack>().addObject(this.id);
			Destroy(this.gameObject);
		}
	}
	public virtual void execute(){
		
	}

}
