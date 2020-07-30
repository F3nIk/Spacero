using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostersSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> boosters;
    [SerializeField] private int maxBoostersForStage;
    [SerializeField] private float chanceOverTime;
    [SerializeField] private float spawnRate;

    [Tooltip("Override lifetime for all boosters.Set 0 to not override(Default lifetime = 60s)")]
    [SerializeField] private float overrideLifetime = 0;
    private bool isOverride => overrideLifetime != 0;

	private void Start()
	{
        //SpawnBoosters();
        StartCoroutine(LerpSpawnBoosters());
	}

	private GameObject GetRandomBooster()
    {
        return boosters[Random.Range(0, boosters.Count-1)];    
	}

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-8, 8), Random.Range(-4, 4));
	}

    private void OverrideBoosterLifetime(Booster booster)
    {
        booster.OverrideLifetime(overrideLifetime);
    }

    private void SpawnBooster()
    {
        var item = Instantiate(GetRandomBooster(), transform);
        item.transform.position = GetRandomPosition();

        if (isOverride) OverrideBoosterLifetime(item.GetComponent<Booster>());
    }

    private void SpawnBoosters()
    {
        var count = 0;
        while(count < maxBoostersForStage)
        {
            SpawnBooster();

            count++;
		}
	}

    private IEnumerator LerpSpawnBoosters()
    {
        var count = 0;
        while(count < maxBoostersForStage)
        {
            var chance = Random.value;
            if(chance < chanceOverTime)
            {
                SpawnBooster();
            }

            count++;

            yield return new WaitForSeconds(spawnRate);
		}
	}
    
}
