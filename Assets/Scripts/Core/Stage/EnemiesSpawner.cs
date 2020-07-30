using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesSpawner : MonoBehaviour
{
	[SerializeField] private List<GameObject> enemyPrefabs;
	private List<GameObject> spawnedEnemies;
    private Transform[] spawnPoints;

	[SerializeField] private float additionalSpawnRange;

	[SerializeField] private float minSpawnDelay;
	[SerializeField] private float maxSpawnDelay;
	[SerializeField] private float checkDelay;

	[SerializeField] private int minAdditionalEnemy;
	[SerializeField] private int maxAdditionalEnemy;
	private float spawnDelay => Random.Range(minSpawnDelay, maxSpawnDelay);

	private int enemyCountInStage => PlayerData.CurrentStage + Random.Range(minAdditionalEnemy, maxAdditionalEnemy);

	public event UnityAction Win;
	public event UnityAction Lose;

	private void Start()
	{
		spawnPoints = GetComponentsInChildren<Transform>();
		SpawnEnemy();
	}

	private void SpawnEnemy()
	{
			StartCoroutine(Spawning());
	}

	private Vector3 GetRandomPosition()
	{
		return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
	}

	private Vector3 GetRandomPositionOpenWorld()
	{
		var center = Camera.main.transform.position;
		var position = center + new Vector3(Random.Range(-additionalSpawnRange, additionalSpawnRange), Random.Range(-additionalSpawnRange, additionalSpawnRange));
		return new Vector3(position.x, position.y, 0);
	}

	private GameObject GetRandomEnemy()
	{
		return enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
	}

	private IEnumerator Spawning()
	{
		spawnedEnemies = new List<GameObject>();
		var count = 0;
		
		while(count < enemyCountInStage)
		{
			var enemy = Instantiate(GetRandomEnemy(), transform);
			enemy.transform.position = GetRandomPositionOpenWorld();

			enemy.GetComponent<Health>().Died += OnDied;
			spawnedEnemies.Add(enemy);
			count++;

			yield return new WaitForSeconds(spawnDelay);
		}

		StartCoroutine(CheckForNoEnemies());
	}

	private IEnumerator CheckForNoEnemies()
	{
		while(true)
		{
			if(spawnedEnemies.Count == 0)
			{
				Win?.Invoke();
			}
			yield return new WaitForSeconds(checkDelay);
		}
	}

	private void OnDied(GameObject obj)
	{
		obj.GetComponent<Health>().Died -= OnDied;
		spawnedEnemies.Remove(obj);
	}

}
