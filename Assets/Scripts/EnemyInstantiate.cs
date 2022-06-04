using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private int _iterationsAmount = 3;

    private Coroutine _enemyCreation;
    private Vector3[] _spawnPositions = new Vector3[3] { new Vector3(-5, -3.5f), new Vector3(0, 4), new Vector3(5, -3.5f) };

    private void Start()
    {
        _enemyCreation = StartCoroutine(SpawnEnemyInPositions());
    }

    private void OnDisable()
    {
        StopCoroutine(_enemyCreation);
    }

    private IEnumerator SpawnEnemyInPositions()
    {
        var waitForTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _iterationsAmount; i++)
        {
            for (int j = 0; j < _spawnPositions.Length; j++)
            {
                CreateEnemy(_spawnPositions[j]);
                yield return waitForTwoSeconds;
            }
        }
    }

    private void CreateEnemy(Vector3 position)
    {
        Instantiate(_enemyTemplate, position, Quaternion.identity);
    }
}