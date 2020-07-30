using UnityEngine;

public class Destructible : MonoBehaviour
{
	private Health health;
	[SerializeField] private ParticleSystem body;

	private void Awake()
	{
		TryGetComponent(out health);
	}

	private void OnEnable()
	{
		health.HealthChange += OnHealthChange;
		health.Died += OnDied;
	}

	private void OnDisable()
	{
		health.HealthChange -= OnHealthChange;
		health.Died -= OnDied;
	}

	private void Start()
	{
		ChangeBodySize();
	}

	private void OnHealthChange(float damage, GameObject source)
	{
		// Add Damage Animations or Other
		ChangeBodySize();


	}

	private void ChangeBodySize()
	{
		body.emissionRate = health.Points.Value;
		body.maxParticles = (int)health.Points.Value;

		//Debug.Log(gameObject.name + " | " + health.Points.Value);
	}

	private void OnDied(GameObject obj)
	{
		// Add Die Animations or Other
		Destroy(obj);
	}
}
