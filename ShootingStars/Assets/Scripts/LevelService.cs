using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelService{

	public static int CurrentScore {
		get;
		set;
	}

	public static int CurrentLevel {
		get;
		set;
	}

	public static bool IsEnemiesCreationAllowed {
		get;
		set;
	}

	public static bool IsNextLevelProcessingStarted {
		get;
		set;
	}
}
