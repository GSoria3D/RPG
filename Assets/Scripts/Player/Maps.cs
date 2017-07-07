using UnityEngine;
using System.Collections.Generic;

public class Maps : MonoBehaviour {

	[System.Serializable]
	public class map{
		public string map1;
		public string map2;
		public Vector3 pos;
	}

	public List<Maps.map> mapping = new List<Maps.map>();
	public string lastMap;
	public string actualMap;

	// Use this for initialization
	void Start () {
	}

	void OnLevelWasLoaded(int level){
		foreach (map m in mapping) {
			if(lastMap == m.map1 && actualMap == m.map2)
				gameObject.transform.position = m.pos;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
