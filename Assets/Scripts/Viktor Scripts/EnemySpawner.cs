using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = 2;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    private GameObject player;

    public float spawnTimeMin;

    public float spawnTimeMax;

    private void Start()
    {
        StartCoroutine(Spawner());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (player == null)
        {
            canSpawn = false;
        }
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            spawnRate = Random.Range(spawnTimeMin, spawnTimeMax);
            yield return wait;

            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
