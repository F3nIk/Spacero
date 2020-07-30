using UnityEngine;
using UnityEngine.Events;

public class ParticlesCollector : MonoBehaviour
{
    private int particles;
    public int Particles => particles;

	private void OnEnable()
	{
		Rewarding.Rewarded += OnRewarded;
	}

	private void OnDisable()
	{
		Rewarding.Rewarded -= OnRewarded;

		PlayerData.AddParticles(particles);
	}

	

	public void OnRewarded(int value)
    {
        particles += value;
	}
}
