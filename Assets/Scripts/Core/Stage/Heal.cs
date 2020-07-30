using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Booster
{
	protected override void OnParticleCollision(GameObject other)
	{
		if (other.tag == "playerBody")
		{
			other.GetComponentInParent<Health>().Heal(amount);
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		if (lifeTimer >= lifetime) Destroy(gameObject);

		lifeTimer += Time.deltaTime;
	}
}
