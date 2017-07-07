using UnityEngine;
using System.Collections.Generic;

public enum questCondition{Hunting,Collect,HuntingAndCollect};
public enum questStatus{Finished,InProgress,Free,Completed};
[System.Serializable]
public class Quests{

	public int id;
	public string name;
	public string questDetail;
	public int previouslyQuestId;
	public int neccesaryLevel;
	public int npcFinish;
	public questCondition condition;
	public bool finished;
	public bool process;
	public int expReward;
	public int moneyReward;
	public List<objectGiven> objectgiven;
	public List<monsterKill> monsterkill;
	public List<objectCollect> objectcollect;
}

[System.Serializable]
public class objectGiven{
	public int id;
	public int amount;
}

[System.Serializable]
public class monsterKill{
	public int id;
	public int amount;
	public int rest = 0;
}

[System.Serializable]
public class objectCollect{
	public int id;
	public int amount;
}