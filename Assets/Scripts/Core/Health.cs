using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Upgradable points;

    public Upgradable Points => points;

    public event UnityAction<float, GameObject> HealthChange;
    public event UnityAction<GameObject> Died;
    private bool isAlive => points.Value > 1;

    public void SetValue(Upgradable value)
    {
        points = value;
	}

    public void Heal(float amount)
    {
        points.AddAmount(amount);    
	}

	public void TryApplyDamage(float damage, GameObject source)
    {
        if (damage < 0) return;
        ApplyDamage(damage,source);
        TryDie();
	}
                                  
    private void ApplyDamage(float damage, GameObject source)
    {
        points.Value -= damage;
        HealthChange?.Invoke(damage,source);
    }

    private void TryDie()
    {
        if (isAlive == false) Died?.Invoke(gameObject);
	}

	private void Start()
	{

    }

}

