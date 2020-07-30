using System.Collections.Generic;
using UnityEngine.Events;

public static class ShopUpgrades
{
	public static int maxUpgradeValue { get; } = 25;
	public static Dictionary<string, int> upgrades { get; private set; } = new Dictionary<string, int>();

	private static int baseUpgradeCost = 10;
	private static float costMultiply = 1.5f;


	public static UnityAction<string, int> ValueChange;

	public static int GetUpgradeValue(string id)
	{
		if (upgrades.ContainsKey(id)) return upgrades[id];
		else return 0;
	}

	public static bool IsAvailbleToUpgrade(string id)
	{
		return upgrades[id] < 25;
	}

	public static void TryUpgradeValue(string id)
	{
		int cost;
		if (upgrades.ContainsKey(id))
		{
			cost = GetUpgrageCost(upgrades[id]);
		}
		else 
		{
			upgrades.Add(id, 0);
			cost = baseUpgradeCost;
		}

		if (IsParticlesEnough(cost))
			UpgradeValue(id, cost);

	}

	private static void UpgradeValue(string id, int cost)
	{
		upgrades[id]++;
		PlayerData.TryWithdrawParticles(cost);
		UpdatePlayerData(id);

		ValueChange?.Invoke(id, upgrades[id]);
	}

	private static void UpdatePlayerData(string id)
	{
		if (id == "Damage") PlayerData.Damage.LevelUp();
		if (id == "Health") PlayerData.Health.LevelUp();
		if (id == "Speed") PlayerData.MovementSpeed.LevelUp();
	} 

	private static int GetUpgrageCost(int level)
	{
		return (int)(baseUpgradeCost * level * costMultiply);	
	}

	private static bool IsParticlesEnough(int cost)
	{
		return PlayerData.Wallet.Particles >= cost;	
	}
}
