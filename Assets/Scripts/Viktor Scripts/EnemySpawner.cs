using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = 2;

    [SerializeField] private List<GameObject> enemyPrefabs;

    [SerializeField] private List<GameObject> enemyPrefabs2;

    [SerializeField] private List<GameObject> enemyPrefabs3;


    [SerializeField] private GameObject dogNPCPrefab;

    [SerializeField] private bool canSpawn = true;

    private GameObject player;

    public float spawnTimeMin;

    public float spawnTimeMax;

    public float timeToSpawn;
    private float spawnTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeToSpawn = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    public void Update()
    {
        if (player == null)
        {
            canSpawn = false;
        }
        else
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= timeToSpawn)
            {
                spawnTimer = 0;
                timeToSpawn = Random.Range(spawnTimeMin, spawnTimeMax);

                int randomSplineNumber = Random.Range(0, 3);

                if (randomSplineNumber == 0)
                {
                    var splines = GameObject.FindGameObjectsWithTag("Spline");
                    if (splines.Length == 0)
                    {
                        Debug.LogError("No splines found with tag 'Spline'");
                    }

                    var splineIndexToSpawnOn = Random.Range(0, splines.Length);
                    var splineToSpawnOn = splines[splineIndexToSpawnOn].GetComponent<SplineContainer>();

                    if (splineToSpawnOn == null)
                    {
                        Debug.LogError("SplineContainer component not found on the selected spline GameObject");
                    }


                    var spawncoords = new Vector3(0, 0, 250);

                    var newNpc = Instantiate(dogNPCPrefab, spawncoords, Quaternion.identity);

                    var dogEnemyNPC = newNpc.transform.GetChild(1);

                    var splineAnimateComponent = dogEnemyNPC.gameObject.GetComponent<SplineAnimate>();

                    splineAnimateComponent.Container = splineToSpawnOn;

                    splineAnimateComponent.Play();


                    var dog = newNpc.transform.GetChild(0);

                    dog.transform.position = new Vector3(dogEnemyNPC.transform.position.x, dogEnemyNPC.transform.position.y, 0);

                }
                else
                {
                    int rand = Random.Range(0, enemyPrefabs.Count);
                    Debug.Log(enemyPrefabs.Count);

                    GameObject enemyToSpawn = enemyPrefabs[rand];

                    Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
                }
            }

        }


    }

    public void evolveEnemySpawns(int evolutionLevel)
    {
        if (evolutionLevel == 1)
        {
            foreach (GameObject enemy in enemyPrefabs2)
            {
                enemyPrefabs.Add(enemy);
            }
        }
        else if (evolutionLevel == 2)
        {
            foreach (GameObject enemy in enemyPrefabs3)
            {
                enemyPrefabs.Add(enemy);
            }
        }
        else
        {
            return;
        }
    }
}
