using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(MainMenuView))]
public class MainMenuController : MonoBehaviour
{
	[SerializeField] private Button previousStage;
	[SerializeField] private Button nextStage;
	[SerializeField] private Button	beginStage;
	[SerializeField] private Button shop;

	private MainMenuView mainMenuView;


	private void OnEnable()
	{
		previousStage.onClick.AddListener(OnPreviousStageClick);
		nextStage.onClick.AddListener(OnNextStageClick);
		beginStage.onClick.AddListener(OnBeginStageClick);
		shop.onClick.AddListener(OnShopClick);
	}

	private void OnDisable()
	{
		previousStage.onClick.RemoveListener(OnPreviousStageClick);
		nextStage.onClick.RemoveListener(OnNextStageClick);
		beginStage.onClick.RemoveListener(OnBeginStageClick);
		shop.onClick.RemoveListener(OnShopClick);
	}

	private void Start()
	{
		PlayerData.EqualCurrentToMaxStage();
		mainMenuView = GetComponent<MainMenuView>();
	}

	public void OnPreviousStageClick()
	{
		PlayerData.PreviousStage();	
	}

	public void OnNextStageClick()
	{
		PlayerData.NextStage();
	}

	public void OnBeginStageClick()
	{
		SceneManager.LoadScene(1,LoadSceneMode.Single);
	}

	public void OnShopClick()
	{
		mainMenuView.OpenShop();	
	}
}
