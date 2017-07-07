using UnityEngine;
using System.Collections;

public class InGameUIStats : MonoBehaviour {
	
	public GUISkin skin;
	
	float leftGroup = 0f;
	float topGroup = 0f;
	float widthGroup = Screen.width * .3f;
	float heightGroup = Screen.height * .2f;
	Stats player;
	public Texture2D HP;
	public Texture2D HPBack;
	public Texture2D SP;
	public Texture2D SPBack;
	public Texture2D money;
	public Texture2D LevelBack;
	public Texture2D frame;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent < Stats>();
		HP.wrapMode = TextureWrapMode.Repeat;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.skin = skin;
		GUI.BeginGroup (new Rect (leftGroup,topGroup,widthGroup,heightGroup));
		GUI.DrawTexture (new Rect (widthGroup * .1f,heightGroup * 0.1f,widthGroup * .2f,heightGroup * .7f), LevelBack,ScaleMode.StretchToFill);
		GUI.Label (new Rect (widthGroup * .1f,heightGroup * 0.1f,widthGroup * .2f,heightGroup * .7f), player.a.level.ToString());
		GUI.skin.label.alignment = TextAnchor.MiddleLeft;
		GUI.Label (new Rect (widthGroup * .45f,heightGroup * 0.1f,widthGroup * .6f,heightGroup * .3f), player.a.money.ToString());
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.DrawTexture (new Rect (widthGroup * .35f, heightGroup * 0.1f, widthGroup * .1f, heightGroup * 0.3f), money,ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (widthGroup * .32f, heightGroup * 0.45f, widthGroup * .66f * player.getPercentHP() / 100, heightGroup * 0.1f), HP,ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (widthGroup * .3f, heightGroup * 0.4f, widthGroup * .7f , heightGroup * 0.2f), frame,ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (widthGroup * .32f, heightGroup * 0.65f, widthGroup * .66f * player.getPercentSP() / 100, heightGroup * 0.1f), SP,ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (widthGroup * .3f, heightGroup * 0.6f, widthGroup * .7f , heightGroup * 0.2f), frame,ScaleMode.StretchToFill);
		GUI.EndGroup ();
	}
}
