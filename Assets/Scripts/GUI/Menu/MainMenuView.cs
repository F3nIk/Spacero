using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [Header("MAIN MENU OBJECTS")]
    [SerializeField] private TextMeshProUGUI stageLabel;
    [SerializeField] private TextMeshProUGUI particlesLabel;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject menu;

	private void OnEnable()
	{
        PlayerData.StageChange += OnStageChange;
        PlayerData.ParticlesChange += OnParticlesChange;
        UpdateAfterSceneChange();

    }

	private void OnDisable()
	{
        PlayerData.StageChange -= OnStageChange;
        PlayerData.ParticlesChange -= OnParticlesChange;
    }

    public void OpenShop()
    {
        shop.SetActive(true);
        menu.SetActive(false);
	}
    
    public void CloseShop()
    {
        shop.SetActive(false);
        menu.SetActive(true);
	}


	public void OnStageChange(int stage)
    {
        stageLabel.text = "Stage " + stage;
	}

    public void OnParticlesChange(int particles)
    {
        particlesLabel.text = particles.ToString();
	}

    private void UpdateAfterSceneChange()
    {
        particlesLabel.text = PlayerData.Wallet.Particles.ToString();
	}

  

}
