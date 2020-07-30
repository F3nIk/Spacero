using UnityEngine;

[RequireComponent(typeof(Rewarding))]
public class EnemyActor : Actor
{
	[SerializeField] private float triggerRange;
	[SerializeField] private new Upgradable movementSpeed;

	private void Start()
	{
		target = FindTarget();	
	}

	protected override void Movement()
    {
		if (target == null || IsTargetInRange() == false) return;
        var dir = target.position - transform.position;
        dir = dir.normalized;
        rb.velocity = new Vector3(dir.x, dir.y, 0f) * movementSpeed.Value;
    }

	protected override Transform FindTarget()
	{
		return GameObject.FindGameObjectWithTag("Player").transform;

	}

	private bool IsTargetInRange()
	{
		return Vector2.Distance(transform.position, target.position) < triggerRange;
	}

	private void OnParticleCollision(GameObject other)
	{
		var target = other.GetComponentInParent<Health>();
		armament.Attack(target);
	}


	
}
