using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private int _iterationsAmount = 3;

    private Coroutine _enemyCreation;
    private Vector3 _enemyPosition1 = new Vector3(-5, -3.5f);
    private Vector3 _enemyPosition2 = new Vector3(0, 4);
    private Vector3 _enemyPosition3 = new Vector3(5, -3.5f);
    private Vector3[] _spawnPositions;

    public EnemyInstantiate()
    {
        _spawnPositions = new Vector3[3]
        {
            _enemyPosition1,
            _enemyPosition2,
            _enemyPosition3
        };
    }

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