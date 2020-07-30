using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageGUIController : MonoBehaviour
{
	[SerializeField] private Button OkWin;
	[SerializeField] private Button OkLose;

	private void OnEnable()
	{
		OkWin.onClick.AddListener(ReturnToMenu);
		OkLose.onClick.AddListener(ReturnToMenu);
	}

	private void OnDisable()
	{
		OkWin.onClick.RemoveListener(ReturnToMenu);
		OkLose.onClick.RemoveListener(ReturnToMenu);
	}

	private void ReturnToMenu()
	{
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}
