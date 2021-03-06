using UnityEngine;
using System.Collections;

public class CrewCombatModule : InternalCombatModule {

	public const ModuleType type = ModuleType.Crew;

	[HideInInspector]
	public int crewLeft = 0;

//	private RelativeScaling contents
	public ShipCrewSystem system;

	public CrewCombatModule() {
		stats = new CrewModuleStats();
	}

	public CrewModuleStats GetStats() {
		return (CrewModuleStats) stats;
	}

//	override protected void Start() {
//		base.Start();
//		contents = GetComponentInChildren<RelativeScaling>() as RelativeScaling;
//	}
//
//	void Update() {
//		contents.max = stats.capacity;
//		contents.current = crewLeft;
//	}

	public int Remove(int toRemove) {
		int leftOver = toRemove - crewLeft;
		if (leftOver > 0) {
			crewLeft = 0;
			return leftOver;
		}
		else {
			crewLeft -= toRemove;
			return 0;
		}
	}

	public int Add(int toAdd) {
		int leftOver = toAdd - (GetStats().capacity - crewLeft);
		if (leftOver > 0) {
			crewLeft = GetStats().capacity;
			return leftOver;
		}
		else {
			crewLeft += toAdd;
			return 0;
		}
	}

	protected override void OnDestroy() {
		if (system == null) {
			return;
		}
		system.RemoveCrewPod(this);
	}

}
