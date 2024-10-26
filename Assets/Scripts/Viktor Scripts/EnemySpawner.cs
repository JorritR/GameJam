using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = 2;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private GameObject regularNPCPrefab;

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

            //int randomSplineNumber = Random.Range(0, 5);
            int randomSplineNumber = 0;

            if (randomSplineNumber == 0)
            {
                var splines = GameObject.FindGameObjectsWithTag("Spline");
                if (splines.Length == 0)
                {
                    Debug.LogError("No splines found with tag 'Spline'");
                    continue;
                }

                var splineIndexToSpawnOn = Random.Range(0, splines.Length);
                var splineToSpawnOn = splines[splineIndexToSpawnOn].GetComponent<SplineContainer>();

                if (splineToSpawnOn == null)
                {
                    Debug.LogError("SplineContainer component not found on the selected spline GameObject");
                    continue;
                }

                var newNpc = Instantiate(regularNPCPrefab, Vector3.zero, Quaternion.identity);
                var splineAnimateComponent = newNpc.AddComponent<SplineAnimate>();

                splineAnimateComponent.Container = splineToSpawnOn;
                splineAnimateComponent.Duration = 10;
                splineAnimateComponent.Alignment = SplineAnimate.AlignmentMode.None;

                // Ensure the SplineAnimate component is properly initialized
                yield return null;
                splineAnimateComponent.Play();
            }
            else
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];

                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            }
        }
    }
}
