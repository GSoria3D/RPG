using UnityEngine;
using System.Collections;

public class Skull : Objects {

	public Texture2D texture;
	public Transform parent;
	void Start (){
	}
	
	public override void execute(){
		parent = GameObject.FindGameObjectWithTag ("Player").transform.FindChild ("Bip01");
		FindTransform (parent, "staff_skull").renderer.material.SetTexture (0, texture);
	}

	public static Transform FindTransform(Transform parent, string name)
	{
		if (parent.name.Equals(name)) return parent;
		foreach (Transform child in parent)
		{
			Transform result = FindTransform(child, name);
			if (result != null) return result;
		}
		return null;
	}
}
