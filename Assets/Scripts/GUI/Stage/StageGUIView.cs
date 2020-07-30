using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageGUIView : MonoBehaviour
{
	[SerializeField] private Health playerHealth;
	[SerializeField] private ParticlesCollector particlesCollector;
	[SerializeField] private GameObject winningPanel;
	[SerializeField] private GameObject losingPanel;

	[SerializeField] private TextMeshProUGUI particlesLabelOnWinningPanel;

	[SerializeField] private EnemiesSpawner enemySpawner;

	private void OnEnable()
	{
		enemySpawner.Win += OnWin;
		playerHealth.Died += OnLose;
	}

	private void OnDisable()
	{
		enemySpawner.Win -= OnWin;
		playerHealth.Died -= OnLose;
	}

	private void OnWin()
	{
		winningPanel.SetActive(true);
		particlesLabelOnWinningPanel.text = "+" + particlesCollector.Particles.ToString();
	}

	private void OnLose(GameObject obj)
	{
		losingPanel.SetActive(true);	
	}
}
