using UnityEngine;
using System.Collections.Generic;

public class AllObjects : MonoBehaviour {

	public List<Objects> objects;

	public Objects getObjectById(int id){
		foreach (Objects o in objects) {
			if(o.id == id)
				return o;
		}
		return null;
	}
}
