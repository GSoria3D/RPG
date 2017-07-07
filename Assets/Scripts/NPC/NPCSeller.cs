using UnityEngine;
using System.Collections.Generic;

public class NPCSeller : NPC {

	public List<GameObject> canSell;
	List<Objects> items;
	PJHaversack haver;
	bool isOpen = false;

	protected Rect rShop = new Rect(Screen.width / 2 - Screen.width * 0.15f,Screen.height * 0.15f,Screen.width * 0.3f,Screen.height*0.7f);
	public Texture2D tShop;

	public GUISkin skinShop;
	Vector3 pos;
	
	float topButton = 0;
	float initialPoint;
	float buttonHeight = 150;
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		items = new List<Objects> ();
		haver = GameObject.FindGameObjectWithTag ("Player").GetComponent<PJHaversack> ();
		foreach (GameObject g in canSell)
			items.Add (g.GetComponent<Objects>());
		initialPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Z)) {
			mustShow = false;
			isOpen = false;
		}
		if (mustShow)
			GameObject.FindGameObjectWithTag ("Player").transform.position = pos;
	}

	protected override void OnMouseDown(){
		base.OnMouseDown ();
		mustShow = true;
		pos = GameObject.FindGameObjectWithTag("Player").transform.position;
		typeMessage = typeTalk.Default;
		message = defaultText;
	}

	protected override void OnGUI(){
		if (mustShow) {
			if(!isOpen)
			{
				GUI.skin = skin;
				GUI.DrawTexture (rBack, talkBackground, ScaleMode.StretchToFill);
				if (typeMessage == typeTalk.Default) {
					GUI.Label (rText, message);
					if (GUI.Button (rAccept, acceptButton)){
						isOpen = true;
					}
					if (GUI.Button (rDecline, cancelButton)){
						mustShow = false;
					}
				}
			} else{
				GUI.DrawTexture(rShop,tShop,ScaleMode.StretchToFill);
				GUI.skin = skin;
				if (GUI.Button (new Rect (rShop.xMax, rShop.height*0.6f, 75f, 50), backQ)) {
					if(initialPoint > -(buttonHeight * (items.Count - 1)))
						initialPoint -= buttonHeight;
				}
				if (GUI.Button (new Rect (rShop.xMax, rShop.height*0.7f, 75f, 50), nextQ)) {
					if(initialPoint < 0)
						initialPoint += buttonHeight;
				}
				topButton = initialPoint;
				GUI.skin = skinShop;
				GUI.BeginGroup(new Rect(rShop.xMin,rShop.height*0.35f, rShop.width,rShop.height*0.85f));
					foreach(Objects o in items){
						GUIContent content = new GUIContent();
						content.image = o.image;
						content.text = o.objectName+"\n"+o.description+"\nPrice:"+o.buyPrice;

						if(GUI.Button(new Rect(0,topButton,rShop.width,buttonHeight),content)){
							if(stp.subMoney(o.buyPrice))
								haver.addObject(o.id);
						}
						topButton += buttonHeight;
					}
				GUI.EndGroup();
			}
		}
	}
}