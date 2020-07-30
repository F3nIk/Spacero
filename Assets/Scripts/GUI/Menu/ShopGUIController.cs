using UnityEngine;
using UnityEngine.UI;

public class ShopGUIController : MonoBehaviour
{
    [SerializeField] private Button damageUpgrade;
    [SerializeField] private Button healthUpgrade;
    [SerializeField] private Button speedUpgrade;

    [SerializeField] private Button home;
    [SerializeField] private Button switchWindow; //TODO mechanic of bossters upgrades

	private void OnEnable()
	{
        damageUpgrade.onClick.AddListener(UpgradeDamage);
        healthUpgrade.onClick.AddListener(UpgradeHealth);
        speedUpgrade.onClick.AddListener(SpeedUpgrade);
	}

	private void OnDisable()
	{
        damageUpgrade.onClick.RemoveListener(UpgradeDamage);
        healthUpgrade.onClick.RemoveListener(UpgradeHealth);
        speedUpgrade.onClick.RemoveListener(SpeedUpgrade);
    }

	public void UpgradeDamage()
    {
        ShopUpgrades.TryUpgradeValue("Damage");
        damageUpgrade.interactable = ShopUpgrades.IsAvailbleToUpgrade("Damage");

    }

    public void UpgradeHealth()
    {
        ShopUpgrades.TryUpgradeValue("Health");
        healthUpgrade.interactable = ShopUpgrades.IsAvailbleToUpgrade("Health");

    }

    public void SpeedUpgrade()
    {
        ShopUpgrades.TryUpgradeValue("Speed");
        speedUpgrade.interactable = ShopUpgrades.IsAvailbleToUpgrade("Speed");

    }
}
