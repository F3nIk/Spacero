using UnityEngine;
[RequireComponent(typeof(Health))]
public class Armament : MonoBehaviour
{
    [SerializeField] private Upgradable damage;
    [SerializeField] private float attackSpeed;
                               
    public Upgradable Damage => damage;
    public float AttackSpeed => attackSpeed;

    private Health health;

	private void Start()
	{
        health = GetComponent<Health>();	
	}

	public void SetValues(Upgradable damage, float speedAmount)
    {
        this.damage = damage;
        attackSpeed = speedAmount;
	}

    public void Attack(Health target)
    {
        target.TryApplyDamage(Damage.Value * Time.deltaTime, gameObject);
        health.TryApplyDamage(Damage.Value * Time.deltaTime, gameObject);
    }
}
