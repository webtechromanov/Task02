using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private int _iterationsAmount = 3;

    private Vector3 _spawnPosition1 = new Vector3(-5, -3.5f);
    private Vector3 _spawnPosition2 = new Vector3(0, 4);
    private Vector3 _spawnPosition3 = new Vector3(5, -3.5f);


    private void Start()
    {
        StartCoroutine(SpawnEnemyInPositions());
    }

    private IEnumerator SpawnEnemyInPositions()
    {
        var waitForTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _iterationsAmount; i++)
        {
            CreateEnemy(_spawnPosition1);
            yield return waitForTwoSeconds;
            CreateEnemy(_spawnPosition2);
            yield return waitForTwoSeconds;
            CreateEnemy(_spawnPosition3);
            yield return waitForTwoSeconds;
        }
    }

    private void CreateEnemy(Vector3 position)
    {
        Instantiate(_enemyTemplate, position, Quaternion.identity);
    }
}
