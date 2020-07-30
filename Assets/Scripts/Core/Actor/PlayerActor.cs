using UnityEngine;

public class PlayerActor : Actor
{
	[SerializeField] private TouchPad touchPad;

	protected override void Awake()
	{
		base.Awake();
		LoadPlayerData();
	}

	protected override void Movement()
	{
		rb.velocity = touchPad.GetDirection() * movementSpeed.Value;
	}

	protected override Transform FindTarget()
	{
		return null;
	}

	private void LoadPlayerData()
	{
		health.SetValue(PlayerData.Health);
		armament.SetValues(PlayerData.Damage, PlayerData.AttackSpeed);
		movementSpeed = PlayerData.MovementSpeed;
	}
}
