using UnityEngine;
using System.Collections.Generic;

public class PJHaversack : MonoBehaviour {


	public static List<int> Haversack = new List<int>();
	public static List<int> numberHaversack = new List<int>();
	AllObjects findObject;
	protected Rect rShop = new Rect(Screen.width / 2 - Screen.width * 0.15f,Screen.height * 0.15f,Screen.width * 0.3f,Screen.height*0.7f);
	public Texture2D tShop;
	
	public GUISkin skin;
	public GUISkin skinShop;
	float topButton = 0;
	float initialPoint;
	float buttonHeight = 150;
	bool mustShow;
	public Texture2D nextQ;
	public Texture2D backQ;
	// Use this for initialization
	void Start () {
		findObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AllObjects> ();
		for (int i = 0; i < Haversack.Count; i++)
			numberHaversack.Add (0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.I))
			mustShow = !mustShow;
		if (mustShow)
			for (int i = 0; i < Haversack.Count; i++)
				Debug.Log (Haversack[i] + " " + numberHaversack [i]);
	}

	public void addObject(int id){
		bool find = false;
		for(int i = 0; i < Haversack.Count; i++){
			if(Haversack[i] == id){
				find = true;
				numberHaversack[i] ++;
				return;
			}
		}
		if (!find) {
			Haversack.Add(id);
			numberHaversack.Add(1);
		}
	}

	public void subObject(int id){
		for(int i = 0; i < Haversack.Count; i++){
			if(Haversack[i] == id){
				numberHaversack[i] --;
				initialPoint = 0;
				return;
			}
		}
	}

	public bool haveObject(int id, int amount){
		for (int i = 0; i < Haversack.Count; i++) {
			if(id == Haversack[i])
				return numberHaversack[i] >= amount;
		}
		return false;
	}

	void OnGUI(){
		if (mustShow) {
				GUI.DrawTexture(rShop,tShop,ScaleMode.StretchToFill);
				GUI.skin = skin;
				if (GUI.Button (new Rect (rShop.xMax, rShop.height*0.6f, 75f, 50), backQ)) {
					if(initialPoint > -(buttonHeight * (Haversack.Count - 1)))
						initialPoint -= buttonHeight;
				}
				if (GUI.Button (new Rect (rShop.xMax, rShop.height*0.7f, 75f, 50), nextQ)) {
					if(initialPoint < 0)
						initialPoint += buttonHeight;
				}
				topButton = initialPoint;
				GUI.skin = skinShop;
				GUI.BeginGroup(new Rect(rShop.xMin,rShop.height*0.35f, rShop.width,rShop.height*0.85f));
				Objects obj;
			for(int i = 0; i <Haversack.Count; i++){
					if(numberHaversack[i] > 0){
						obj = findObject.getObjectById(Haversack[i]);
						GUIContent content = new GUIContent();
						content.image = obj.image;
						content.text = obj.objectName+"\n"+obj.description+"\nQuantity:"+numberHaversack[i];
						
						if(GUI.Button(new Rect(0,topButton,rShop.width,buttonHeight),content)){
							obj.execute();
						}
						topButton += buttonHeight;
					}
				}
				GUI.EndGroup();
			
		}
	}
}
