using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rewarding : MonoBehaviour
{
	[SerializeField] private int rewardValue;

	public static event UnityAction<int> Rewarded;

	private void OnDestroy()
	{
		Rewarded?.Invoke(rewardValue);
	}



}
