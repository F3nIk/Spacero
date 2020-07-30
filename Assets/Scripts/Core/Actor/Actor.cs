using UnityEngine;

[RequireComponent(typeof(Health), typeof(Destructible), typeof(Armament))]
public abstract class Actor : MonoBehaviour
{
	protected Health health;
	protected Armament armament;
	protected Rigidbody2D rb;
	protected new Transform transform;
	protected Transform target;
	protected Upgradable movementSpeed;


	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		transform = GetComponent<Transform>();
		health = GetComponent<Health>();
		armament = GetComponent<Armament>();
		target = null;
	}

	private void Update()
	{
		Movement();
	}

	protected abstract void Movement();

	protected abstract Transform FindTarget();


}
