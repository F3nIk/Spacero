using UnityEngine.Events;

public static class PlayerData
{
	private static int currentStage = 1;
	private static int maxStage = 10;
	private static Upgradable health = new Upgradable(100);
	private static Upgradable damage = new Upgradable(5);
	private static float attackSpeed = 1;
	private static Upgradable movementSpeed = new Upgradable(1.25f);

	private static Wallet wallet;
	public static int CurrentStage => currentStage;
	public static int MaxStage => maxStage;
	public static Upgradable Health => health;
	public static Upgradable Damage => damage;
	public static float AttackSpeed => attackSpeed;
	public static Upgradable MovementSpeed => movementSpeed;

	public static Wallet Wallet => wallet;

	public static UnityAction<int> StageChange;
	public static UnityAction<int> ParticlesChange;
	public static void PreviousStage()
	{
		if (currentStage > 1) currentStage--;
		StageChange?.Invoke(currentStage);
	}

	public static void NextStage()
	{
		if(currentStage < maxStage) currentStage++;
		StageChange?.Invoke(currentStage);
	}

	public static void EqualCurrentToMaxStage()
	{
		currentStage = maxStage;
		StageChange?.Invoke(currentStage);
	}

	public static void AddParticles(int value)
	{
		wallet.ChangeParticles(value);
		ParticlesChange?.Invoke(wallet.Particles);
	}

	public static bool TryWithdrawParticles(int value)
	{
		if (wallet.Particles > value)
		{
			wallet.ChangeParticles(-value);
			ParticlesChange?.Invoke(wallet.Particles);
			return true;
		}
		else return false;
	}
}
