using UnityEngine;
using System.Collections.Generic;
using System;

public class Attacks : MonoBehaviour {

	[Serializable]
	public class Attack
	{
		public string name;
		public GameObject p;
		public int damage;
		public int necessaryLevel;
		public int sp;
		public Texture2D texture;
	}
	public Attack[] attacks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
