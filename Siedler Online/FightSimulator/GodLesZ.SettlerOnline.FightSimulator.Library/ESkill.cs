
namespace GodLesZ.SettlerOnline.FightSimulator.Library {

	public enum ESkill {
		/// <summary>
		/// Bonus damage vs. buildings +250%
		/// </summary>
		DamageBonusBuildings250 = 1,
		/// <summary>
		/// Bonus damage vs. units +250%
		/// </summary>
		DamageBonusUnits250,
		/// <summary>
		/// Attacks weakest unit first   
		/// </summary>
		AttackWeakestFirst,
		/// <summary>
		/// Splash damage		
		/// </summary>
		SplashDamage,
		/// <summary>
		/// Bonus Tower Armor	
		/// </summary>
		BonusTowerArmor,
		/// <summary>
		/// First Strike   
		/// </summary>
		FirstStrike,
		/// <summary>
		/// Last Strike
		/// </summary>
		LastStrike,
		/// <summary>
		/// Ignores [x] % armor vs units in tower
		/// </summary>
		IgnoreUnitArmorInTower,
		/// <summary>
		/// Is Specialist       
		/// </summary>
		IsSpecialist
	}

}
