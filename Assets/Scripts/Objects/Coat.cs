using UnityEngine;
using System.Collections;

public class Coat : Objects {
	public Texture2D texture;
	public Transform g;
	void Start (){
	}

	public override void execute(){
		g = GameObject.FindGameObjectWithTag ("Player").transform.FindChild ("necromancer");
		g.renderer.material.SetTexture (0, texture);
	}
}
