using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSMeter : MonoBehaviour 
{
	public TextMeshProUGUI fpsLabel;
    public int Fps => (int)(1f / Time.deltaTime);

    private string outFps;

	private void OnEnable()
	{
		StartCoroutine(metric());	
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private void Start()
	{
		
	}

	private IEnumerator metric()
    {
		while(true)
		{
			fpsLabel.text = Fps.ToString();
			yield return new WaitForSeconds(1f);
		}
	}
}
