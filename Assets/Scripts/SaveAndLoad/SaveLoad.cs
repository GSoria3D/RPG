using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {
	static List<float> pos = new List<float>();

	public static void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames001.sg"); //you can call it anything you want
		bf.Serialize(file, Stats.current);
		file.Close();
		file = File.Create (Application.persistentDataPath + "/savedGames002.sg"); //you can call it anything you want
		bf.Serialize(file, PJHaversack.Haversack);
		file.Close();
		file = File.Create (Application.persistentDataPath + "/savedGames003.sg"); //you can call it anything you want
		bf.Serialize(file, PJHaversack.numberHaversack);
		file.Close();
		file = File.Create (Application.persistentDataPath + "/savedGames004.sg"); //you can call it anything you want
		bf.Serialize(file, AdminQuest.q);
		file.Close();
		file = File.Create (Application.persistentDataPath + "/savedGames005.sg"); //you can call it anything you want
		bf.Serialize(file, Application.loadedLevelName);
		file.Close();
		file = File.Create (Application.persistentDataPath + "/savedGames006.sg"); //you can call it anything you want
		pos.Clear ();
		pos.Add (GameObject.FindGameObjectWithTag ("Player").transform.position.x);
		pos.Add (GameObject.FindGameObjectWithTag ("Player").transform.position.y);
		pos.Add (GameObject.FindGameObjectWithTag ("Player").transform.position.z);
		bf.Serialize(file, pos);
		file.Close();
	}
	
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames001.sg")) {
			InitialMenuScript.loaded = true;
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames001.sg", FileMode.Open);
			GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().a = (Stats.Attribute)bf.Deserialize(file);
			file.Close();
			file = File.Open(Application.persistentDataPath + "/savedGames002.sg", FileMode.Open);
			PJHaversack.Haversack = (List<int>)bf.Deserialize(file);
			file.Close();
			file = File.Open(Application.persistentDataPath + "/savedGames003.sg", FileMode.Open);
			PJHaversack.numberHaversack = (List<int>)bf.Deserialize(file);
			file.Close();
			file = File.Open(Application.persistentDataPath + "/savedGames004.sg", FileMode.Open);
			GameObject.FindGameObjectWithTag("QuestObject").GetComponent<AdminQuest>().quests = (List<Quests>)bf.Deserialize(file);
			file.Close();
			file = File.Open(Application.persistentDataPath + "/savedGames005.sg", FileMode.Open);
			Application.LoadLevel((string)bf.Deserialize(file));
			file.Close();
			file = File.Open(Application.persistentDataPath + "/savedGames006.sg", FileMode.Open);
			pos = (List<float>)bf.Deserialize(file);
			GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(pos[0],pos[1],pos[2]);
			file.Close();
			GameObject.FindGameObjectWithTag("Player").GetComponent<Maps>().actualMap = "Town";
			GameObject.FindGameObjectWithTag("Player").GetComponent<Maps>().lastMap = "Town";
			Time.timeScale = 1f;
		}
	}
}
