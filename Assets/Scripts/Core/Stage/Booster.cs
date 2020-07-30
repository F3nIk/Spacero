using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Booster : MonoBehaviour
{
    [SerializeField] protected float amount;
    [SerializeField] protected float duration;
    [SerializeField] protected float lifetime;

    protected float lifeTimer = 0;

	protected virtual void Start()
	{
		var body = GetComponentInChildren<ParticleSystem>();
		body.startLifetime = lifetime;
	}

	protected abstract void OnParticleCollision(GameObject other);

	public virtual void OverrideLifetime(float lifetime)
    {
        if (lifetime > 0)
			this.lifetime = lifetime;
	}
}
