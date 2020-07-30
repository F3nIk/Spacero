using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGUIView : MonoBehaviour
{
	[SerializeField] private List<Slider> sliders;
	private Dictionary<string, Slider> bars = new Dictionary<string, Slider>();

	private void Awake()
	{
		foreach(var slider in sliders)
		{
			bars.Add(slider.tag, slider);
		}
	}

	private void OnEnable()
	{
		ShopUpgrades.ValueChange += OnValueChanged;	
	}

	private void OnDisable()
	{
		ShopUpgrades.ValueChange -= OnValueChanged;
	}

	private void OnValueChanged(string id, int value)
	{
		bars[id].value = GetRatio(value);
	}

	private float GetRatio(int value)
	{
		return (float)value / 25;

	}

}
